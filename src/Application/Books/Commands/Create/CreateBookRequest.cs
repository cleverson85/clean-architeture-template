using Domain.Enums;
using Domain.Entities;
using Application.Core.Contract;
using Application.Interfaces.Messaging;

namespace Application.Books.Commands.Create;

public class CreateBookRequest : CoreOperationRequest, ICommand<CoreOperationResponse>
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public BookType Type { get; set; }

    public static implicit operator Book(CreateBookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
        Type = bookRequest.Type,
    };
}
