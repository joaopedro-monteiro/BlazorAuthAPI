using BlazorAuthAPI.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.Config
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    "Server=localhost;Database=BlazorAuthAPI;User Id=sa;Password=ef66b58b-6ff2-4c78-bcec-6b279312b625;TrustServerCertificate=True;MultipleActiveResultSets=true;"));
        }
    }
}
