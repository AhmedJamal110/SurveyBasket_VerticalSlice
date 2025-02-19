
namespace SurveyBasket_VerticalSlice.Persistence.Configration;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasIndex(vote => new { vote.PollId, vote.UserId })
                  .IsUnique();



    }
}
