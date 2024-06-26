using Application.Core.Services;
using Application.Interfaces.Base;
using Application.Interfaces.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Infrastructure.Data.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books;

public class GetBookOperatation : CoreOperationAsync<GetBookRequest, GetBookResponse>, IGetBookOperation
{
	private readonly IDistributedCache _cache;

	public GetBookOperatation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<GetBookRequest, GetBookResponse>> logger, IDistributedCache cache) : base(unitOfWork, logger)
	{
		_cache = cache;
	}

	protected override async Task<GetBookResponse> ProcessOperationAsync(GetBookRequest request, CancellationToken cancellationToken)
	{
		if (request.Id != Guid.Empty)
		{
			return await _cache.GetOrCreateAsync($"book-{request.Id}", async () =>
			{
				var result = (GetBookResponse)await _unitOfWork.BookRepository.GetAsync(request.Id, cancellationToken);
				return result;
			});
		}

		return await _unitOfWork.BookRepository.GetAllAsync(cancellationToken);
	}
}
