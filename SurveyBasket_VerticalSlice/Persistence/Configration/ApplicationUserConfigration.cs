using SurveyBasket_VerticalSlice.Domain.Identity;

namespace SurveyBasket_VerticalSlice.Persistence.Configration
{
    public class ApplicationUserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.OwnsMany(user => user.refreshTokens)
                      .ToTable("RefreshTokens")
                      .WithOwner()
                      .HasForeignKey("UserId");

            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
