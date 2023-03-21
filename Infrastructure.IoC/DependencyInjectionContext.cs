using Infrastructure.Data.Contexts;
using Infrastructure.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.IoC;

public static class DependencyInjectionContext
{
    public static void Register(IServiceCollection services)
    {
        services.ConfigureOptions<DataBaseOptionsSetup>();

        services.AddDbContext<Context>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DataBaseOptions>>()!.Value;

            options.UseNpgsql(databaseOptions.ConnectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlOptions.CommandTimeout(databaseOptions.CommandTimeout);
            });

            options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        });
    }
}
