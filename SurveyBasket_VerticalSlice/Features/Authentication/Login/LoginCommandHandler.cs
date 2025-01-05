using Microsoft.AspNetCore.Identity;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider;
using SurveyBasket_VerticalSlice.Features.Authentication.Shared;
using System.Security.Cryptography;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Login
{
    public class LoginCommandHandler : BaseRequestHandler<LoginCommand, Result<UserResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly int _refreshTokenExpireIn = 14;
        public LoginCommandHandler(RequestParameters parameters  , UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result<UserResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result.Failure<UserResponse>(UserError.UserNotFound);

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkPassword)
                return Result.Failure<UserResponse>(UserError.UserNotFound);

            (string token, int expireIn) = await _sender.Send(new CreateTokenCommand(user));

            var refreshToken = RandomRefreshToken.GenerateRefreshToken();
            var refreshTokenExpire = DateTime.UtcNow.AddDays(_refreshTokenExpireIn);

            user.refreshTokens.Add(new Domain.Identity.RefreshToken
            {
                Token = refreshToken,
                ExpireOn = refreshTokenExpire
            });

            await _userManager.UpdateAsync(user);

            return Result.Success(new UserResponse(user.Id, user.Email!, user.FirstName, user.LastName, token, expireIn , refreshToken , refreshTokenExpire));
        }  
    }
}
