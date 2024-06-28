using WebApp.Middlewares;

namespace WebApp;

public static class Service
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly));
    }
}
