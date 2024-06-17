using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace WebApp.FuncionalTests;

public class WebAppTest : BaseWebAppTestApi
{
    public WebAppTest(WebApplicationFactory<Program> applicationFactory) : base(applicationFactory)
    { }

    [Fact]
    public async Task Book_ShouldGetOK()
    {
        var result = await _httpClient.GetAsync($"/api/v1/book");
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
