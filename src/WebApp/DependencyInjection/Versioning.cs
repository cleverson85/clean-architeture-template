using Asp.Versioning;

namespace WebApp.DependencyInjection;

public static class Versioning
{
    public static void Register(IServiceCollection services)
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
}
