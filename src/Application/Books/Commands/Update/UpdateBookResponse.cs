using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Commands.Update;

public sealed class UpdateBookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }

    public static explicit operator UpdateBookResponse(Book book) => new()
    {
        Book = book,
    };
}