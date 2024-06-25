using Infrastructure.Data.Options;
using WebApp.OpenApi;

namespace WebApp.DependencyInjection
{
    public static class OptionsPattern
    {
        public static void Register(IServiceCollection services)
        {
            services.ConfigureOptions<DataBaseOptionsSetup>();
            services.ConfigureOptions<ConfigureSwaggerGenOptions>();
            services.ConfigureOptions<RedisOptionsSetup>();
        }
    }
}
