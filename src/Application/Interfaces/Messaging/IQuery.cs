using Application.Core.Contract;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface IQuery<TResponse> : IRequest<CoreOperationResponse>
{ }