namespace SurveyBasket_VerticalSlice.Features.Authentication.RevokeTokenCQ
{
    public record RevokeTokenCommand(string Token, string RefreshToken) : IRequest<Result>;

}
