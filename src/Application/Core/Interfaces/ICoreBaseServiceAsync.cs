using FluentValidation.Results;

namespace Application.Core.Interfaces;

public interface ICoreBaseServiceAsync<TRequest, TResponse> : IDisposable where TRequest : CoreOperationRequest where TResponse : CoreOperationResponse, new()
{
    Task<TResponse> ProcessAsync(TRequest request, CancellationToken cancellationToken);
    Task<ValidationResult> ValidateOperationAsync(TRequest request, CancellationToken cancellationToken);
}

