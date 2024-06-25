using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Response.Books
{
    public class GetBookResponse : CoreOperationResponse
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
        public Book Book { get; set; } = new Book();

        public static implicit operator GetBookResponse(List<Book> books)
        {
            return new()
            {
                Books = books,
            };
        }

        public static explicit operator GetBookResponse(Book book) => new()
        {
            Book = book,
        };
    }
}
