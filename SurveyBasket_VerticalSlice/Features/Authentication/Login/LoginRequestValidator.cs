namespace SurveyBasket_VerticalSlice.Features.Authentication.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(token => token.Email).NotEmpty().EmailAddress();
            RuleFor(token => token.Password).NotEmpty();

        }
    }
}
