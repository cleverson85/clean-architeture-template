namespace WebApp.DependencyInjection;

public static class Cors
{
    public static void Register(IServiceCollection services, string corsPolicy)
    {
        services.AddCors(options => options.AddPolicy(corsPolicy,
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                       .AllowAnyMethod()
                                       .AllowAnyHeader();
                            }));
    }
}
