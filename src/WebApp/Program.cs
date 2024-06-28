using Infrastructure.Data.Contexts;
using Serilog;
using Asp.Versioning.ApiExplorer;
using WebApp;
using WebApp.Middlewares;

const string CorsPolicy = "corsPolicy";
const string HealthPath = "/health";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddHealthChecks();
services.SetupInjection(CorsPolicy);

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

    app.ApplyMigration();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(CorsPolicy);
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks(HealthPath);
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

app.Run();

public partial class Program { }