using Domain.Entities;

namespace Core.Contracts.Response.Books
{
    public class GetBookResponse : CoreOperationResponse
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
    }
}
