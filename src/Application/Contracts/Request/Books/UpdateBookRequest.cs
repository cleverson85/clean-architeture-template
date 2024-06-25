using Application.Contracts.Request.Books;
using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Request.Books;

public class UpdateBookRequest : CoreOperationRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public Book Book { get; set; } = new Book();

    public static implicit operator UpdateBookRequest(Book book) => new()
    {
        Book = book,
    };
}
