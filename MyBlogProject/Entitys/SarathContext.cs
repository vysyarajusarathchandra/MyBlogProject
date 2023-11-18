using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyBlogProject.Repo;

namespace MyBlogProject.Entitys
{
    public class SarathContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        IConfiguration config = null;
        public SarathContext(IConfiguration cfg)
        {
            config = cfg;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config["ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c => c.CategoryName).IsUnique(true);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique(true);
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
