
namespace SurveyBasket_VerticalSlice.Persistence.Configration
{
    public class QuestionConfigration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasIndex(ques => new { ques.PollId, ques.Content }).IsUnique();
            builder.Property(ques => ques.Content).HasMaxLength(1000);
        }
    }
}
