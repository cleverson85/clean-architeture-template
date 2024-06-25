using Application.Interfaces.Repository;
using Infrastructure.Data.Repositories;

namespace WebApp;

public static class Repository
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
