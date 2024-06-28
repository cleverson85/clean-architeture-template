using Application.Core.Contract;
using Application.Interfaces.Messaging;
using FluentValidation.Results;

namespace Application.Core.Interfaces
{
    public interface ICoreBaseOperationAsync<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>, IDisposable
        where TRequest : CoreOperationRequest
        where TResponse : CoreOperationResponse, new()
    {
        Task<ValidationResult> ValidateOperationAsync(TRequest request, CancellationToken cancellationToken);
    }

}