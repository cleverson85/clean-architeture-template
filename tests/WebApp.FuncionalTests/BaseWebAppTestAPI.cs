using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebApp.FuncionalTests;

public abstract class BaseWebAppTestApi : IClassFixture<WebApplicationFactory<Program>>
{
    protected readonly HttpClient _httpClient;

    protected BaseWebAppTestApi(WebApplicationFactory<Program> applicationFactory)
    {
        _httpClient = applicationFactory.CreateClient();
    }
}
