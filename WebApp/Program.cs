using Application.Middlewares;
using Infrastructure.Data.Contexts;
using Infrastructure.IoC;
using Serilog;

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
services.ExecuteMigration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
