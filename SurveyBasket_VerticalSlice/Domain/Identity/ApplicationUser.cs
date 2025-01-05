using Microsoft.AspNetCore.Identity;

namespace SurveyBasket_VerticalSlice.Domain.Identity
{
    public sealed class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<RefreshToken> refreshTokens { get; set; } = [];
    }
}
