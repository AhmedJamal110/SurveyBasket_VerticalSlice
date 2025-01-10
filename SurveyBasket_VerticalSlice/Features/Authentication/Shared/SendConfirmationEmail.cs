using SurveyBasket_VerticalSlice.Domain.Identity;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Shared
{
    public static class SendConfirmationEmail
    {
        public static Result<string> SendAndResendConfirmationEmail(HttpContext httpContext ,  ApplicationUser user , string code )
        {
            if (httpContext is null)
                return Result.Failure<string>(new Error("HttpContextNull", "HttpContext"));

            if (user is null)
                return Result.Failure<string>(UserError.IvalidCredentials);

            if (string.IsNullOrEmpty(code))
                return Result.Failure<string>(UserError.InvalidCode);

            var origin = httpContext.Request.Headers.Origin;
            var link = $"{origin}/ConfirmEmaiEndPoint?userId={user.Id}&code={code}";

            var emailBody = EmailBodyBuillder.GenerateEmailBody("EmailConfigration", new Dictionary<string, string>
            {
                {"{{Name}}" , user.FirstName },
               {"{{action_url}}" ,  $"{origin}/api/ConfirmEmaiEndPoint?userId={user.Id}&code={code}"}
           });

            var logger = httpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                                                                         .CreateLogger("Send and Resend Email Confirmation");


            logger.LogInformation("Code  => : {Code }, Email => {Email}, link =>  {Link}  "
                , code, user.Email, link);

            return emailBody;
        }
    }
}
