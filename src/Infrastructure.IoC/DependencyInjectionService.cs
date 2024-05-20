using Application.Interfaces.Books;
using Application.Middlewares;
using Application.Services.Books;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionService
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ErrorHandlingMiddleware>();
        services.AddScoped<ICreateBookOperation, CreateBookOperation>();
        services.AddScoped<IGetBookOperation, GetBookOperatation>();
        services.AddScoped<IUpdateBookOperation, UpdateBookOperation>();
    }
}
