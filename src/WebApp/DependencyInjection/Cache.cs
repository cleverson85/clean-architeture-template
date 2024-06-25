namespace WebApp;

public static class Cache
{
  public static void Register(IServiceCollection services)
  {
    string connectionString = builder.Configuration.GetConnectionString("Redis");
    IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
    services.AddSingleton(connectionMultiplexer);

    services.AddStackExchangeRedisCache(options =>
    {
      options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
    });
  }
}
