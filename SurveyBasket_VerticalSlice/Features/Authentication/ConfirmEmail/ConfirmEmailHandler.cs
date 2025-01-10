
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SurveyBasket.Abstractions;
using SurveyBasket_VerticalSlice.Domain.Identity;
using System.Security.AccessControl;
using System.Text;

namespace SurveyBasket_VerticalSlice.Features.Authentication.ConfirmEmail
{
    public class ConfirmEmailHandler : BaseRequestHandler<ConfirmEmailCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailHandler(RequestParameters parameters , UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return Result.Failure(UserError.IvalidCredentials);

            if (user.EmailConfirmed)
                return Result.Failure(UserError.ConfirmEmailDuplicated);

            var code = request.Code;

            try
            {
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            }
            catch (FormatException)
            {
                return Result.Failure(UserError.InvalidCode);
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
                return Result.Success();

            var error = result.Errors.First();
            return Result.Failure(new Error( error.Code, error.Description));


        }
    }
}
