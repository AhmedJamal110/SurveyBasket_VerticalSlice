
using Microsoft.AspNetCore.Identity;
using SurveyBasket_VerticalSlice.Domain.Identity;

namespace SurveyBasket_VerticalSlice.Features.Authentication.ResendConfirmationEmail
{
    public class ResendConfirmationEmailHandler : BaseRequestHandler<ResendConfirmationEmailCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResendConfirmationEmailHandler(RequestParameters parameters , UserManager<ApplicationUser> userManager) : base(parameters)
        {
            _userManager = userManager;
        }

        public override async Task<Result> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
        {
           var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null)
                    return Result.Success();    // Make it appear as if the email exists. 

            if (user.EmailConfirmed)
                return Result.Failure(UserError.ConfirmEmailDuplicated);

            // send Email 

           return Result.Success();
        }
    }
}
