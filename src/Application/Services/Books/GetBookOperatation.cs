using Application.Interfaces.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Core.Services;
using Domain.Interfaces.Base;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books;

public class GetBookOperatation : CoreOperationAsync<GetBookRequest, GetBookResponse>, IGetBookOperation
{
    public GetBookOperatation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<GetBookRequest, GetBookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override async Task<GetBookResponse> ProcessOperationAsync(GetBookRequest request, CancellationToken cancellationToken)
    {
         var result = await _unitOfWork.BookRepository.GetAllAsync(cancellationToken);
        return new GetBookResponse() { Books = result };
    }
}
