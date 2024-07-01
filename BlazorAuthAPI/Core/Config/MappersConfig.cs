using BlazorAuthAPI.Api.Users.Mappers;

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
