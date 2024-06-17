using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Response.Books
{
    public class GetBookResponse : CoreOperationResponse
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();

        public static implicit operator GetBookResponse(List<Book> books)
        {
            return new()
            {
                Books = books,
            };
        }
    }
}
