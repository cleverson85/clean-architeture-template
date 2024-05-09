using Application.Interfaces;
using Application.Middlewares;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionService
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ErrorHandlingMiddleware>();
        services.AddScoped<IBookOperation, CreateBookOperation>();
    }
}
