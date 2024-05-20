using Application.Middlewares;
using Infrastructure.Data.Options;
using Infrastructure.Data.Contexts;
using Infrastructure.IoC;
using Serilog;
using Asp.Versioning;
using WebApp.OpenApi;
using Asp.Versioning.ApiExplorer;

const string CorsPolicy = "CorsPolicy";
const string HealthPath = "/health";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigureInjection();
services.AddCors(options => options.AddPolicy(CorsPolicy,
                 builder =>
                 {
                     builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                 }));
services.AddHealthChecks();
services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("X-Api-Version"));

    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });
services.ConfigureOptions<DataBaseOptionsSetup>();
services.ConfigureOptions<ConfigureSwaggerGenOptions>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

        foreach (ApiVersionDescription description in descriptions)
        {
            string url = $"/swagger/{description.GroupName}/swagger.json";
            string name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
    services.ExecuteMigration();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(CorsPolicy);
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks(HealthPath);
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
