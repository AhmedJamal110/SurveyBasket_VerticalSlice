namespace SurveyBasket_VerticalSlice.Features.Authentication.Shared
{
    public record UserResponse
    (
        string Id,
        string Email,
        string FirstName,
        string LastName,
        string Token,
        int ExpireIn,
        string RefreshToken,
        DateTime RefreshTokenExpireIn
     );
}
