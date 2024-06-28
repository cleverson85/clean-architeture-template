using Application.Core.Services;
using Application.Validators.Books;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Books.Commands.Create;

internal sealed class CreateBookCommandHandler : CoreOperationAsync<CreateBookRequest, CreateBookResponse>
{
    public CreateBookCommandHandler(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<CreateBookRequest, CreateBookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override async Task<CreateBookResponse> ProcessOperationAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.BookRepository.SaveAsync((Book)request, cancellationToken);
        return (CreateBookResponse)result;
    }

    protected override async Task<ValidationResult> ValidateAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var validator = new BookCreateValidation();
        return await validator.ValidateAsync((Book)request, cancellationToken);
    }
}
