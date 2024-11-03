using Microsoft.EntityFrameworkCore;
using instakcal_backend.Domain.Entities;

namespace instakcal_backend.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Image> Images { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            modelBuilder.Entity<Image>()
                .HasKey(image => image.Id);
        }
    }
}