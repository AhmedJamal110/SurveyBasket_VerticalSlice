namespace SurveyBasket_VerticalSlice.Domain.Entities
{
    public sealed class Poll : BaseEntity
    {
       public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;

        public bool IsPublished { get; set; }
        public DateOnly StratsAT { get; set; }
        public DateOnly EndAt { get; set; }
        public ICollection<Answer> Questions { get; set; } = [];
    }
}
