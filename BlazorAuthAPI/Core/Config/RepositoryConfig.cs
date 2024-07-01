using BlazorAuthAPI.Core.Repository.User;

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
