using Application.Books.Commands.Update;
using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Commands.Delete;

public sealed class DeleteBookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static explicit operator DeleteBookResponse(Book book) => new()
    {
        Book = book,
    };
}
