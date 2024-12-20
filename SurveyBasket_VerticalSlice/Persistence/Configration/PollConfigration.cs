namespace SurveyBasket_VerticalSlice.Persistence.Configration
{
    public class PollConfigration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasIndex(x => x.Title).IsUnique()
                       .HasDatabaseName("IX_Poll_Title");

            builder.Property(x => x.Title).HasMaxLength(1500);
            builder.Property(x => x.Summary).HasMaxLength(1500);
        }
    }
}
