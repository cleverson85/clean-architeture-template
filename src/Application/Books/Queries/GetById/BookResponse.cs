using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Queries.GetById;

public sealed class BookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static explicit operator BookResponse(Book book) => new()
    {
        Book = book,
    };
}

