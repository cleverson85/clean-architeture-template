using Application.Interfaces.Base;
using Infrastructure.Data;
using Infrastructure.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApp;

public static class Context
{
    public static void Register(IServiceCollection services)
    {
        services.AddDbContext<Infrastructure.Data.Contexts.Context>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DataBaseOptions>>()!.Value;

            options.UseNpgsql(databaseOptions.ConnectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: databaseOptions.MaxRetryCount, 
                    maxRetryDelay: TimeSpan.FromSeconds(30), 
                    errorCodesToAdd: null);
                sqlOptions.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
