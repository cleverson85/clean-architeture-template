using Application.Books.Commands.Create;
using Application.IntegrationTests.Abstractions;
using Bogus;
using Domain.Entities;
using Domain.Enums;

namespace Application.IntegrationTests.Books
{
    public class CreateBookTest : BaseIntegrationTest
    {
        public CreateBookTest(IntegrationTestWebAppFactory factory) : base(factory)
        { }

        [Fact]
        public async Task Create_Should_CreateBook_WhenCommandIsValid()
        {
            //Arrange
            var request = new CreateBookRequest(Faker.Internet.UserName(), Faker.Name.LastName(), BookType.Terror);

            //Act
            var result = await Sender.Send(request);

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task Create_Should_CreateBookToDataBase_WhenCommandIsValid()
        {
            //Arrange
            var request = new CreateBookRequest(Faker.Internet.UserName(), Faker.Name.LastName(), BookType.Terror);

            //Act
            var result = await Sender.Send(request);

            //Assert
            Book? book = await DbContext.Book.FindAsync((result as CreateBookResponse).Book);
            Assert.NotNull(book);
        }
    }
}
