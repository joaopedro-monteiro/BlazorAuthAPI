using BlazorAuthAPI.Api.Users.Services;

namespace BlazorAuthAPI.Core.Config
{
    public static class ServicesConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
