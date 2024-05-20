using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Contracts.Request.Books;

public class BookRequest : CoreOperationRequest
{
    [Required]
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public static implicit operator Book(BookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
    };
}
