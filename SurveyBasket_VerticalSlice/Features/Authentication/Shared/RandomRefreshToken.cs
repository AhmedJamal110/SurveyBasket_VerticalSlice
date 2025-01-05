using System.Security.Cryptography;

namespace SurveyBasket_VerticalSlice.Features.Authentication.Shared
{
    public static class RandomRefreshToken
    {
        public static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
