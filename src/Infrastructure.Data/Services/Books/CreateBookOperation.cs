using Application.Contracts.Request.Books;
using Application.Core.Services;
using Application.Interfaces.Base;
using Application.Interfaces.Books;
using Application.Mappers;
using Application.Validation.Books;
using Core.Contracts.Response.Books;
using Domain.Entities;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Services.Books;

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
