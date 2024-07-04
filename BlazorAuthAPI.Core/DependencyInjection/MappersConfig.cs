using BlazorAuthAPI.Core.User.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.DependencyInjection
{
    public static class MappersConfig
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IUserMapper, UserMapper>();
        }
    }
}
