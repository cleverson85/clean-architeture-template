using Asp.Versioning;
using WebApp.DependencyInjection;

namespace WebApp;

public static class Injection
{
    const string CorsPolicy = "CorsPolicy";

    public static void ConfigureInjection(this IServiceCollection services)
    {
        ConfigureCors(services);
        ConfigureVersioning(services);
        ConfigureOtherStuffs(services);

        OptionsPattern.Register(services);
        Context.Register(services);
        Repository.Register(services);
        Service.Register(services);
        Cache.Register(services);
    }

    private static void ConfigureOtherStuffs(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();
    }

    private static void ConfigureVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));

        }).AddMvc()
          .AddApiExplorer(options =>
          {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
          });
    }

    private static void ConfigureCors(IServiceCollection services)
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