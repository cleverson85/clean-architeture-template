using Application.Core.Contract;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces.Messaging;
using Domain.Interfaces.Base;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Books.Queries.GetById;

internal sealed class GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IDistributedCache cache) : IQueryHandler<GetBookByIdQuery, BookResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDistributedCache _cache = cache;

    public async Task<CoreOperationResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _cache.GetOrCreateAsync($"book-{request.Id}", async () =>
        {
            var book = (BookResponse)await _unitOfWork.BookRepository.GetAsync(request.Id, cancellationToken);
            return book;
        });

        if (result is null)
        {
            return new BookNotFoundException(request.Id);
        }

        return result;
    }
}
