using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.Options;

public class RedisOptionsSetup : IConfigureOptions<RedisOptions>
{
    private const string ConfigurationSectionName = "Redis";
    private readonly IConfiguration _configuration;

    public RedisOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(RedisOptions options)
    {
        var connecionString = _configuration.GetConnectionString("ConnectionString");
        options.ConnectionString = connecionString!;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}