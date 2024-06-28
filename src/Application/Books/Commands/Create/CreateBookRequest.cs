using Domain.Enums;
using Domain.Entities;
using Application.Interfaces.Messaging;
using Application.Core.Contract;

namespace Application.Books.Commands.Create;

public sealed class CreateBookRequest : CoreOperationRequest, ICommand
{
    public CreateBookRequest(string author, string title, BookType type)
    {
        Author = author;
        Title = title;
        Type = type;
    }

    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public BookType Type { get; set; }

    public static explicit operator Book(CreateBookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
        Type = bookRequest.Type,
    };
}
