using BlazorAuthAPI.Core.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.DependencyInjection
{
    public static class ServicesConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
