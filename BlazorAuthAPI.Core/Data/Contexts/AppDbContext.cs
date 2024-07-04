using BlazorAuthAPI.Core.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User.Entities.User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=BlazorAuthAPI;User Id=sa;Password=ef66b58b-6ff2-4c78-bcec-6b279312b625;TrustServerCertificate=True;MultipleActiveResultSets=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfig());
        }
    }
}
