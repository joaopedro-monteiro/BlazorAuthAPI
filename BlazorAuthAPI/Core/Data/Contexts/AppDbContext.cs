using BlazorAuthAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
