using Domain.Entities;

namespace Core.Contracts;

public class BookRequest : CoreOperationRequest
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public static implicit operator Book(BookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
    };
}
