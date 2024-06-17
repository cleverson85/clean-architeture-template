using Application.Core;
using Core.Contracts.Response.Books;
using Domain.Entities;

namespace Application.Contracts.Request.Books;

public class CreateBookRequest : CoreOperationRequest
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public static implicit operator Book(CreateBookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
    };
}
