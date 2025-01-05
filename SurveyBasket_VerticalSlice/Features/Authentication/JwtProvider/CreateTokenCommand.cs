using SurveyBasket_VerticalSlice.Domain.Identity;

namespace SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider
{
    public record CreateTokenCommand(ApplicationUser user) : IRequest<(string token , int expireIn)>;
    
}
