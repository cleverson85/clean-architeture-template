using Application.Core.Contract;
using Application.Interfaces.Messaging;
using FluentValidation.Results;

namespace Core.Interfaces;

public interface ICoreBaseServiceAsync<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>, IDisposable 
    where TRequest : CoreOperationRequest 
    where TResponse : CoreOperationResponse, new()
{
    Task<TResponse> ProcessAsync(TRequest request, CancellationToken cancellationToken);
    Task<ValidationResult> ValidateOperationAsync(TRequest request, CancellationToken cancellationToken);
}

