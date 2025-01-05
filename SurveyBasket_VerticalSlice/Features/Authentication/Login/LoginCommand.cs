using SurveyBasket_VerticalSlice.Features.Authentication.Shared;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Login
{
    public record LoginCommand (string Email , string Password) : IRequest<Result<UserResponse>>;
    
}
