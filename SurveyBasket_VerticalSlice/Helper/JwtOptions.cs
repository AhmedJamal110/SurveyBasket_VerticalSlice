namespace SurveyBasket_VerticalSlice.Helper
{
    public class JwtOptions
    {
        public static string SectionName = "Token";
        public string Key { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudiance  { get; set; } = string.Empty;
        public int ExpireMinutes { get; set;}
    }
}
