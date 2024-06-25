using Infrastructure.Data.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace WebApp.DependencyInjection;

public static class Cache
{
    public static void Register(IServiceCollection services)
    {
        var redisConnection = services.BuildServiceProvider().GetService<IOptions<RedisOptions>>()!.Value;
        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnection.ConnectionString);
        services.AddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(options =>
        {
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
        });
    }
}
