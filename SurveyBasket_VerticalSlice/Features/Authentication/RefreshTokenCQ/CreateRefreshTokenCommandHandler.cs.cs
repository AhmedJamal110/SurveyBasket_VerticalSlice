using Microsoft.AspNetCore.Identity;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider;
using SurveyBasket_VerticalSlice.Features.Authentication.Shared;
using SurveyBasket_VerticalSlice.Features.Authentication.ValidateToken;

namespace SurveyBasket_VerticalSlice.Features.Authentication.RefreshTokenCQ
{
    public class CreateRefreshTokenHandler : BaseRequestHandler<CreateRefreshTokenCommand, Result<UserResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly int _refreshTokenExpireIn = 14;
        public CreateRefreshTokenHandler(RequestParameters parameters , UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result<UserResponse>> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
           var userId = await  _sender.Send(new ValidateTokenCommand(request.Token));
                if (string.IsNullOrEmpty(userId))
                    return Result.Failure<UserResponse>(UserError.UserNotFound);

            var user = await _userManager.FindByIdAsync(userId);
                if (user is null)
                    return Result.Failure<UserResponse>(UserError.UserNotFound);

            var refrshToken = user.refreshTokens.SingleOrDefault(token => token.Token == request.RefrshToken && token.IsActive);
                if (refrshToken is null)
                    return Result.Failure<UserResponse>(UserError.TokenError);

            refrshToken.RevokeOn = DateTime.UtcNow;

            var (newToken, newExpireIn) = await _sender.Send(new CreateTokenCommand(user));
            var newRefreshToken = RandomRefreshToken.GenerateRefreshToken();
            var newRefreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpireIn);

            user.refreshTokens.Add(new Domain.Identity.RefreshToken
            {
                Token = newRefreshToken,
                ExpireOn = newRefreshTokenExpiration
            });

            await _userManager.UpdateAsync(user);

            return Result.Success(new UserResponse(user.Id, user.Email, user.FirstName, user.LastName
                                                                , newToken, newExpireIn, newRefreshToken, newRefreshTokenExpiration));
        }
    }
}
