namespace SurveyBasket_VerticalSlice.Features.Authentication.ConfirmEmail
{
    public class ConfirmEmailValidate : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailValidate()
        {
            RuleFor(temp => temp.UserId).NotEmpty();
            RuleFor(temp => temp.Code).NotEmpty();
        }
    }
}
