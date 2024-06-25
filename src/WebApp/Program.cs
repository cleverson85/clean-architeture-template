using Application.Middlewares;
using Infrastructure.Data.Contexts;
using Serilog;
using Asp.Versioning.ApiExplorer;
using WebApp;

const string CorsPolicy = "CorsPolicy";
const string HealthPath = "/health";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;

services.ConfigureInjection();

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

public partial class Program { }