namespace SurveyBasket_VerticalSlice.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public Poll Poll { get; set; } = default!;
        public int PollId { get; set; }

        public ICollection<Answer> Answers { get; set; } = [];
    }
}
