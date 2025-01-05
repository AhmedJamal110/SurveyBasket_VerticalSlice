using Microsoft.AspNetCore.Identity;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider;
using SurveyBasket_VerticalSlice.Features.Authentication.Shared;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Register
{
    public class RegisterCommandHandler : BaseRequestHandler<RegisterCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(RequestParameters parameters , UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
             // Email Uniqe
            var emailExist = await _userManager.Users.AnyAsync(user => user.Email == request.Email);
            if (emailExist)
                return Result.Failure(UserError.EmailDuplicated);
            
            var user = request.Adapt<ApplicationUser>();

            var result = await _userManager.CreateAsync(user, request.Password);
            if (! result.Succeeded)
            {
                var errors = result.Errors.First();

                return Result.Failure(new Error(errors.Code, errors.Description));
            }

            var (token, expireIn) = await _sender.Send(new CreateTokenCommand(user));
            string refreshToken = RandomRefreshToken.GenerateRefreshToken();
            DateTime refreshTokenExpiration = DateTime.UtcNow.AddDays(14);

            user.refreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpireOn = refreshTokenExpiration
            });

            await _userManager.UpdateAsync(user);

            return Result.Success();
        }
    }
}
