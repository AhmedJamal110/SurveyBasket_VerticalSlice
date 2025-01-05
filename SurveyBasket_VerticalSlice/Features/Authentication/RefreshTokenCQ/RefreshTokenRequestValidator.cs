namespace SurveyBasket_VerticalSlice.Features.Authentication.RefreshTokenCQ
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(token => token.Token).NotEmpty();
            RuleFor(token => token.RefreshToken).NotEmpty();
        }
    }
}
