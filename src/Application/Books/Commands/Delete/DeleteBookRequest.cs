using Application.Core.Contract;
using Application.Interfaces.Messaging;

namespace Application.Books.Commands.Delete;

public sealed class DeleteBookRequest(Guid Id) : CoreOperationRequest, ICommand
{
    public Guid Id { get; } = Id;
}
