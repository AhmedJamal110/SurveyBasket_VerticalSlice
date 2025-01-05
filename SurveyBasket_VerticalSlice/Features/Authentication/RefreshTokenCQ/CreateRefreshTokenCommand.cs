using SurveyBasket_VerticalSlice.Features.Authentication.Shared;

namespace SurveyBasket_VerticalSlice.Features.Authentication.RefreshTokenCQ
{
    public record CreateRefreshTokenCommand(string Token , string RefrshToken):IRequest<Result<UserResponse>>;
  
}
