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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly int _refreshTokenExpireIn = 14;
        public LoginCommandHandler(RequestParameters parameters  ,UserManager<ApplicationUser> userManager 
            ,SignInManager<ApplicationUser> signInManager) : base(parameters)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<Result<UserResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return Result.Failure<UserResponse>(UserError.IvalidCredentials);

            //var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (signInResult.Succeeded)
            {
                (string token, int expireIn) = await _sender.Send(new CreateTokenCommand(user));

                var refreshToken = RandomRefreshToken.GenerateRefreshToken();
                var refreshTokenExpire = DateTime.UtcNow.AddDays(_refreshTokenExpireIn);

                user.refreshTokens.Add(new RefreshToken
                {
                    Token = refreshToken,
                    ExpireOn = refreshTokenExpire
                });

                await _userManager.UpdateAsync(user);
                return Result.Success(new UserResponse(user.Id, user.Email!, user.FirstName
                    ,user.LastName, token, expireIn, refreshToken, refreshTokenExpire));
            }

            if(signInResult.IsNotAllowed)
               return Result.Failure<UserResponse>(UserError.EmailNotConfirmed);

            return Result.Failure<UserResponse>(UserError.IvalidCredentials);

        }  
    }
}
