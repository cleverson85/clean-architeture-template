using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Response.Books;

public class BookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }
}
