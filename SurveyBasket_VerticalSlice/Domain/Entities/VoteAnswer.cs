namespace SurveyBasket_VerticalSlice.Domain.Entities;

public sealed class VoteAnswer : BaseEntity
{

    public Vote Vote { get; set; } = default!;
    public int VoteId { get; set; }


    public Question Question { get; set; } = default!;
    public int QuestionId { get; set; }

    public Answer Answer { get; set; } = default! ;
    public int AnswerId { get; set; }

}
