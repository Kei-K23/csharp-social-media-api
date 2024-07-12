using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.AppDataContext
{
    public class PostDbContext : DbContext
    {
        private readonly DBSettings _dbSettings;

        public PostDbContext(IOptions<DBSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .ToTable("tb_posts")
                .HasKey(p => p.Id);
        }
    }
}