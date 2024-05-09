using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Contexts;

public static class Migration
{
    public static void ExecuteMigration(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

		try
		{
			var context = serviceProvider.GetRequiredService<Context>();
			context.Database.Migrate();
		}
		catch (Exception)
		{

		}
    }
}
