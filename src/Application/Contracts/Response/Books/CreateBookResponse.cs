using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Response.Books;

public class CreateBookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static implicit operator CreateBookResponse(Book book) => new()
    {
        Book = book,
    };
}
