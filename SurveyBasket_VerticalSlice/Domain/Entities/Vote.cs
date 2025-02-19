using SurveyBasket_VerticalSlice.Domain.Identity;

namespace SurveyBasket_VerticalSlice.Domain.Entities;

public sealed class Vote : BaseEntity
{
    public Poll Poll { get; set; } = default!;
    public int PollId { get; set; }

    public ApplicationUser User { get; set; } = default!;
    public string UserId { get; set; } = string.Empty;

    public ICollection<VoteAnswer> VoteAnswers { get; set; } = default!;

    public int VoteAnswersId { get; set; }
}
