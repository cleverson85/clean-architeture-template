using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.Options;

public class DataBaseOptionsSetup : IConfigureOptions<DataBaseOptions>
{
    private const string ConfigurationSectionName = "DatabaseOptions";
    private readonly IConfiguration _configuration;

    public DataBaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DataBaseOptions options)
    {
        var connecionString = _configuration.GetConnectionString("DefaultConnection");
        options.ConnectionString = connecionString!;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
