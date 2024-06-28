using Application.Interfaces.Messaging;
using Domain.Enums;

namespace Application.Books.Commands.Create;

public sealed record CreateBookCommand(string Author, string Title, BookType Type) : ICommand
{ }

