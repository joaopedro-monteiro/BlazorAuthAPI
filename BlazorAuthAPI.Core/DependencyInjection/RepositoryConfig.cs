using BlazorAuthAPI.Core.Repository.User;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.Config
{
    public static class RepositoryConfig
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
