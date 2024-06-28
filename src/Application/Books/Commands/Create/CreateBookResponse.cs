using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Commands.Create;

public class CreateBookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static implicit operator CreateBookResponse(Book book) => new()
    {
        Book = book,
    };
}
