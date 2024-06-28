using Application.Core.Contract;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface ICommand : IRequest<CoreOperationResponse>
{ }

public interface ICommand<TResponse> : IRequest<TResponse>
{ }
