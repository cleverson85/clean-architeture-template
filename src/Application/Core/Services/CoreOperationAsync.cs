using Application.Core.Contract;
using Application.Core.Interfaces;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Core.Services;

public abstract class CoreOperationAsync<TRequest, TResponse> : ICoreBaseOperationAsync<TRequest, TResponse>
    where TRequest : CoreOperationRequest
    where TResponse : CoreOperationResponse, new()
{
    protected bool _disposed;
    protected IUnitOfWork _unitOfWork;
    protected ILogger<CoreOperationAsync<TRequest, TResponse>> _logger;

    protected CoreOperationAsync(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<CoreOperationResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        TResponse response = new TResponse();

        try
        {
            _logger.LogDebug("Initiating operation.");
            _logger.LogDebug("Initiating request validation.");
            ValidationResult validationResult = await ValidateOperationAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogDebug($"Validation status is invalid to class {typeof(TRequest)}.");
                response.Errors = validationResult.Errors;
                return response;
            }

            var executionStrategy = _unitOfWork.Context.Database.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _unitOfWork.BeginTransacionAsync();
                try
                {
                    response = await ProcessOperationAsync(request, cancellationToken);
                    await _unitOfWork.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

            return response;
        }
        catch (Exception e)
        {
            _logger.LogDebug($"Occurred a error in transaction process. {e.StackTrace}");
            await _unitOfWork.RollBackTransactionAsync();

            response.Errors.Add(new ValidationFailure()
            {
                ErrorCode = "123",
                ErrorMessage = e.Message,
            });

            return response;
        }
    }

    protected abstract Task<TResponse> ProcessOperationAsync(TRequest request, CancellationToken cancellationToken);

    public async Task<ValidationResult> ValidateOperationAsync(TRequest request, CancellationToken cancellationToken)
    {
        return await ValidateAsync(request, cancellationToken);
    }

    protected virtual async Task<ValidationResult> ValidateAsync(TRequest request, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            _logger.LogInformation("Validation function wasn't found in the concrete class.");
            return new CoreOperationResponse();
        });
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (this == null)
                {
                    Dispose();
                }
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
