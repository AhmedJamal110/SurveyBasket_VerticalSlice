namespace SurveyBasket_VerticalSlice.Features.Authentication.ResendConfirmationEmail
{
    public class ResendConfirmationEmailValidation : AbstractValidator<ResendConfirmationEmailRequest>
    {
        public ResendConfirmationEmailValidation()
        {
            RuleFor(temp => temp.Email).NotEmpty().EmailAddress();            
        }
    }
}
