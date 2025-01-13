using MockProject.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace MockProject.Persistence.DataAccess
{
    internal class MockProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MockProjectDbContext(DbContextOptions<MockProjectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(n => n.Id)
                .HasName("PK_UserId");
        }
    }
}
