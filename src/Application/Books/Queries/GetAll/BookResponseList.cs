using Application.Core.Contract;
using Domain.Entities;

namespace Application.Books.Queries.GetAll;

public sealed class BookResponseList : CoreOperationResponse
{
    public List<Book> Books { get; set; } = [];

    public static explicit operator BookResponseList(List<Book> books) => new()
    {
        Books = books,
    };
}

