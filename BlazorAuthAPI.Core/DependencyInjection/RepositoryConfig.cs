using BlazorAuthAPI.Core.User.Repository.User;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.DependencyInjection
{
    public static class RepositoryConfig
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
