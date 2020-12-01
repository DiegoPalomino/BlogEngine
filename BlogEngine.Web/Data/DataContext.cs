using BlogEngine.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(t => t.Title)
                .IsUnique();

            modelBuilder.Entity<Post>()
                .HasIndex(t => t.Title)
                .IsUnique();
        }
    }
}
