using Application.Core.Services;
using Application.Interfaces.Base;
using Application.Interfaces.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books;

public class GetBookOperatation : CoreOperationAsync<GetBookRequest, GetBookResponse>, IGetBookOperation
{
    public GetBookOperatation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<GetBookRequest, GetBookResponse>> logger) : base(unitOfWork, logger)
    { }

    protected override async Task<GetBookResponse> ProcessOperationAsync(GetBookRequest request, CancellationToken cancellationToken)
    {
         var result = await _unitOfWork.BookRepository.GetAllAsync(cancellationToken);
        return result;
    }
}
