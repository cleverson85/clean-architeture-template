using Application.Core.Contract;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, CoreOperationResponse>
    where TQuery : IQuery<CoreOperationResponse>
{
}
