using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.AppDataContext
{
    public class AppDbContext : DbContext
    {
        private readonly DBSettings _dbSettings;

        public AppDbContext(IOptions<DBSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        // DB set property to represent user table
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("tb_users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Post>()
                .ToTable("tb_posts")
                .HasKey(p => p.Id);
        }
    }
}