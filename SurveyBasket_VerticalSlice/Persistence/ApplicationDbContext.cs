using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SurveyBasket_VerticalSlice.Extension;

namespace SurveyBasket_VerticalSlice.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyCascadeRestrictionsConfigration();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Answer> Questions { get; set; }
        public DbSet<Answer> Answers  { get; set; }
    }
}
