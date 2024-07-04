using BlazorAuthAPI.Api.Users.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAuthAPI.Core.Config
{
    public static class MappersConfig
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddScoped<IUserMapper, UserMapper>();
        }
    }
}
