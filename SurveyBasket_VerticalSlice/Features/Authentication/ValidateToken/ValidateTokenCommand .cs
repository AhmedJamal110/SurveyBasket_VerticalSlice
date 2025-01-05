namespace SurveyBasket_VerticalSlice.Features.Authentication.ValidateToken
{
    public record ValidateTokenCommand(string Token) : IRequest<string?>;
    
}
