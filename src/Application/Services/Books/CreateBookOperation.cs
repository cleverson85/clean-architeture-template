using Application.Interfaces.Books;
using Application.Mappers;
using Application.Validation.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Core.Services;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books;

public class CreateBookOperation : CoreOperationAsync<BookRequest, BookResponse>, ICreateBookOperation
{
    public CreateBookOperation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<BookRequest, BookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override async Task<BookResponse> ProcessOperationAsync(BookRequest request, CancellationToken cancellationToken)
    {
        Book book = request;
        var result = await _unitOfWork.BookRepository.SaveAsync(book, cancellationToken);
        return result.Map();
    }

    protected override async Task<ValidationResult> ValidateAsync(BookRequest request, CancellationToken cancellationToken)
    {
        var validator = new BookCreateValidation();
        return await validator.ValidateAsync(request, cancellationToken);
    }
}
