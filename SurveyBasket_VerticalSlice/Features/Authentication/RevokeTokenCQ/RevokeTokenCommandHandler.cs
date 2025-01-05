
using Microsoft.AspNetCore.Identity;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.ValidateToken;

namespace SurveyBasket_VerticalSlice.Features.Authentication.RevokeTokenCQ
{
    public class RevokeTokenCommandHandler : BaseRequestHandler<RevokeTokenCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RevokeTokenCommandHandler(RequestParameters parameters, UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var userId = await _sender.Send(new ValidateTokenCommand(request.Token));
            if (string.IsNullOrEmpty(userId))
                return Result.Failure(UserError.TokenError);

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result.Failure(UserError.TokenError);

            var refreshToken = user.refreshTokens.SingleOrDefault(token => token.Token == request.RefreshToken && token.IsActive);
            if (refreshToken is null)
                return Result.Failure(UserError.TokenError);

            refreshToken.RevokeOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return Result.Success();

        }
    }
}
