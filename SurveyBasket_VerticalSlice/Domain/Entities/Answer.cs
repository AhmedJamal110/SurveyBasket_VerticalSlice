namespace SurveyBasket_VerticalSlice.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public Question  Question { get; set; } = default!;
        public int QuestionId { get; set; }
    }
}
