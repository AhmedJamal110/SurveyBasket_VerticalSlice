namespace SurveyBasket_VerticalSlice.Features.Authentication.Register
{
    public class RegisterRequestValidators : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidators()
        {
            RuleFor(register => register.FirstName).NotEmpty()
                                                                      .Length(3, 100);       
            
            RuleFor(register => register.LastName).NotEmpty()
                                                                     .Length(3, 100);

            RuleFor(register => register.Email).NotEmpty()
                                                                .EmailAddress();
            
            RuleFor(register => register.Password).NotEmpty()
                                                                     .MinimumLength(8);
        }
    }
}
