using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider;
using SurveyBasket_VerticalSlice.Features.Authentication.Shared;
using System.Text;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Register
{
    public class RegisterCommandHandler : BaseRequestHandler<RegisterCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterCommandHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;

        public RegisterCommandHandler(RequestParameters parameters,UserManager<ApplicationUser> userManager 
            ,ILogger<RegisterCommandHandler> logger 
            ,IHttpContextAccessor httpContextAccessor , IEmailSender emailSender) : base(parameters)
        {
            _userManager = userManager;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }

        public override async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Email Uniqe
            var emailExist = await _userManager.Users.AnyAsync(user => user.Email == request.Email);
            if (emailExist)
                return Result.Failure(UserError.EmailDuplicated);

            var user = request.Adapt<ApplicationUser>();

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.First();

                return Result.Failure(new Error(errors.Code, errors.Description));
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var emailBody = SendConfirmationEmail.SendAndResendConfirmationEmail(_httpContextAccessor.HttpContext, user , code);

            if (emailBody.IsFailure)
            {
                var errors = result.Errors.First();
                return Result.Failure(new Error(errors.Code, errors.Description));
            }

            await _emailSender.SendEmailAsync(user.Email!, "Suervey Basket : Confirmation Email", emailBody.Value);


            return Result.Success();
        }
    }
}
