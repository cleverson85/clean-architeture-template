using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Commands.Create;

public sealed class CreateBookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static explicit operator CreateBookResponse(Book book) => new()
    {
        Book = book,
    };
}
