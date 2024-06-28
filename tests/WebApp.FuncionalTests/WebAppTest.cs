using Application.Books.Commands.Create;
using Application.IntegrationTests.Abstractions;
using Bogus;
using Domain.Enums;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace WebApp.FuncionalTests;

public class WebAppTest : BaseIntegrationTest
{
    public WebAppTest(IntegrationTestWebAppFactory factory) : base(factory)
    { }

    [Fact]
    public async Task Return_Book_ShouldGetOK()
    {
        //Act
        var result = await HttpClient.GetAsync($"/api/v1/book");

        //Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Create_Should_CreateBookAndGetOk_WhenRequestIsValid()
    {
        //Arrange
        var request = new CreateBookRequest(Faker.Internet.UserName(), Faker.Name.LastName(), BookType.Terror);

        //Act
        var httpResponse = await HttpClient.PostAsJsonAsync($"/api/v1/book", request);

        //Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Create_Should_CreateBookAndGetBadRequest_WhenRequestIsInvalid()
    {
        //Arrange
        var request = new CreateBookRequest("", "", BookType.Terror);

        //Act
        var httpResponse = await HttpClient.PostAsJsonAsync($"/api/v1/book", request);

        //Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
