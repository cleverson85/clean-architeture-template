using Application.Core.Contract;
using Application.Core.Services;
using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Books.Commands.Update;

internal sealed class UpdateBookCommandHandler(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>> logger) 
    : CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>(unitOfWork, logger)
{
    private Book _book = new();

    protected override async Task<UpdateBookResponse> ProcessOperationAsync(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        _book.Author = request.Author;
        _book.Title = request.Title;
        _book.Type = request.Type;

        var result = await _unitOfWork.BookRepository.UpdateAsync(_book, cancellationToken);
        return (UpdateBookResponse)result;
    }

    protected override async Task<ValidationResult> ValidateAsync(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        _book = await _unitOfWork.BookRepository.GetAsync(request.Id, cancellationToken);

        if (_book is null)
        {
            return new BookNotFoundException(request.Id);
        }

        return new CoreOperationResponse();
    }
}
