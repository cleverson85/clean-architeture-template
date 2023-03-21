using Domain.Interfaces.Repository;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionRepository
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
