
namespace SurveyBasket_VerticalSlice.Persistence.Configration
{
    public class AnswerConfigration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasIndex(answer => new { answer.QuestionId, answer.Content });
            builder.Property(answer => answer.Content).HasMaxLength(1000);
        }
    }
}
