namespace WebApp.DependencyInjection;

public static class Cors
{
    const string CorsPolicy = "CorsPolicy";

    public static void Register(IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy(CorsPolicy,
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                       .AllowAnyMethod()
                                       .AllowAnyHeader();
                            }));
    }
}
