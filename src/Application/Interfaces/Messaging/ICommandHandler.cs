using Application.Core.Contract;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, CoreOperationResponse>
    where TRequest : ICommand
{ }

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, CoreOperationResponse>
    where TRequest : ICommand<CoreOperationResponse>
    where TResponse : CoreOperationResponse
{ }