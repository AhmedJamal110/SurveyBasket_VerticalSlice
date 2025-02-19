
namespace SurveyBasket_VerticalSlice.Persistence.Configration;

public class VoteAnswerConfiguration : IEntityTypeConfiguration<VoteAnswer>
{
    public void Configure(EntityTypeBuilder<VoteAnswer> builder)
    {
        builder.HasIndex(voteAns => new { voteAns.VoteId, voteAns.QuestionId })
                  .IsUnique();


    }
}
