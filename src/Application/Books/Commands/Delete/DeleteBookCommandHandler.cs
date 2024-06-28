using Application.Core.Contract;
using Application.Core.Services;
using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Books.Commands.Delete;

internal sealed class DeleteBookCommandHandler(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<DeleteBookRequest, DeleteBookResponse>> logger)
    : CoreOperationAsync<DeleteBookRequest, DeleteBookResponse>(unitOfWork, logger)
{
    private Book _book = new();

    protected override async Task<DeleteBookResponse> ProcessOperationAsync(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository.DeleteAsync(_book, cancellationToken);
        return (DeleteBookResponse)result;
    }

    protected override async Task<ValidationResult> ValidateAsync(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        _book = await _unitOfWork.BookRepository.GetAsync(request.Id, cancellationToken);

        if (_book is null)
        {
            return new BookNotFoundException(request.Id);
        }

        return new CoreOperationResponse();
    }
}
