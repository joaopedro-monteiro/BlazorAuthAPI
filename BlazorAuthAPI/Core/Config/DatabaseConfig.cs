using BlazorAuthAPI.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthAPI.Core.Config
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
        }
    }
}
