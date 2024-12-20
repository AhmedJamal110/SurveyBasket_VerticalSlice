using Microsoft.EntityFrameworkCore;
using SurveyBasket_VerticalSlice.Domain.Entities;
using System.Reflection;

namespace SurveyBasket_VerticalSlice.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Poll> Polls { get; set; }
    }
}
