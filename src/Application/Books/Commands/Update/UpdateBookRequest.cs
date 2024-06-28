using Application.Core.Contract;
using Application.Interfaces.Messaging;
using Domain.Entities;
using Domain.Enums;

namespace Application.Books.Commands.Update;

public sealed class UpdateBookRequest : CoreOperationRequest, ICommand
{
    public Guid Id { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public BookType Type { get; set; }

    public static explicit operator Book(UpdateBookRequest bookRequest) => new()
    {
        Author = bookRequest.Author,
        Title = bookRequest.Title,
        Type = bookRequest.Type,
    };
}
