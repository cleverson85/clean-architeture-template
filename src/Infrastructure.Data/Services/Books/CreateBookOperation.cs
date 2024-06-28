using Application.Contracts.Request.Books;
using Application.Core.Services;
using Application.Interfaces.Books;
using Application.Validation.Books;
using Core.Contracts.Response.Books;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Services.Books;

public class CreateBookOperation : CoreOperationAsync<CreateBookRequest, CreateBookResponse>, ICreateBookOperation
{
    public CreateBookOperation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<CreateBookRequest, CreateBookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override async Task<CreateBookResponse> ProcessOperationAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository.SaveAsync(request, cancellationToken);
        return result;
    }

    protected override async Task<ValidationResult> ValidateAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var validator = new BookCreateValidation();
        return await validator.ValidateAsync(request, cancellationToken);
    }
}
