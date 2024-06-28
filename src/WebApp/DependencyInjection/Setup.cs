using Asp.Versioning;
using WebApp.DependencyInjection;

namespace WebApp;

public static class Setup
{
    public static void SetupInjection(this IServiceCollection services, string corsPolicy)
    {
        ConfigureOtherStuffs(services);

        OptionsPattern.Register(services);
        Cors.Register(services, corsPolicy);
        Cache.Register(services);
        Context.Register(services);
        Versioning.Register(services);
        Repository.Register(services);
        Service.Register(services);
    }

    private static void ConfigureOtherStuffs(IServiceCollection services)
    {
        
    }
}