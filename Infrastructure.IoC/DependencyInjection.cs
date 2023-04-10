using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjection
{
    public static void ConfigureInjection(this IServiceCollection services)
    {
        DependencyInjectionContext.Register(services);
        DependencyInjectionRepository.Register(services);
        DependencyInjectionService.Register(services);
    }
}