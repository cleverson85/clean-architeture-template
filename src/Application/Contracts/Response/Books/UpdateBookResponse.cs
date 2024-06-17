using Application.Core;
using Core.Contracts.Request.Books;
using Domain.Entities;

namespace Core.Contracts.Response.Books
{
    public class UpdateBookResponse : CoreOperationResponse
    {
        public Book? Book { get; set; }

        public static explicit operator UpdateBookResponse(Book book) => new()
        {
            Book = book,
        };
    }
}
