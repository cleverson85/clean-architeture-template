using Bogus;
using Infrastructure.Data.Contexts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Application.IntegrationTests.Abstractions;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected ISender Sender { get; }
    protected Context DbContext { get; }
    protected Faker Faker { get; }
    protected HttpClient HttpClient { get; }

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<Context>();
        Faker = new Faker();
        HttpClient = factory.CreateClient();
    }

    public void Dispose()
    {
        _scope?.Dispose();
    }
}
