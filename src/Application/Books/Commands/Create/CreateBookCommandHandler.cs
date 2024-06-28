using Application.Core.Contract;
using Application.Core.Services;
using Application.Interfaces.Messaging;
using Domain.Interfaces.Base;
using Microsoft.Extensions.Logging;

namespace Application.Books.Commands.Create;

internal sealed class CreateBookCommandHandler : CoreOperationAsync<CreateBookRequest, CreateBookResponse>
{
    public CreateBookCommandHandler(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<CreateBookRequest, CreateBookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override Task<CreateBookResponse> ProcessOperationAsync(CreateBookRequest request, CancellationToken cancellationToken)
    {
        
    }
}
