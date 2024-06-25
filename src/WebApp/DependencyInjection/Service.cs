using Application.Interfaces.Books;
using Application.Middlewares;
using Application.Services.Books;
using Infrastructure.Data.Services.Books;

namespace WebApp;

public static class Service
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ErrorHandlingMiddleware>();
        services.AddScoped<ICreateBookOperation, CreateBookOperation>();
        services.AddScoped<IGetBookOperation, GetBookOperatation>();
        services.AddScoped<IUpdateBookOperation, UpdateBookOperation>();
        services.AddScoped<IDeleteBookOperation, DeleteBookOperation>();
    }
}
