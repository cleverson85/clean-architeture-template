using Domain.Interfaces.Base;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public abstract class CoreOperationAsync<TRequest, TResponse> : CoreBaseOperationAsync<TRequest, TResponse>
        where TRequest : CoreOperationRequest
        where TResponse : CoreOperationResponse, new()
    {
        protected CoreOperationAsync(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<TRequest, TResponse>> logger) : base(unitOfWork, logger)
        { }
    }
}
