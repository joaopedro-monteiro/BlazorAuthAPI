using BlazorAuth.Services;

namespace BlazorAuth.Config
{
    public static class ServicesConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
