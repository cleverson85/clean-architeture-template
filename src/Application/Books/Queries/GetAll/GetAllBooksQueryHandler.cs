using Application.Core.Contract;
using Application.Interfaces.Messaging;
using Domain.Interfaces.Base;


namespace Application.Books.Queries.GetAll;

internal sealed class GetAllBooksQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetAllBooksQuery, BookResponseList>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CoreOperationResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.BookRepository.GetAllAsync(cancellationToken);
        return (BookResponseList)books;
    }
}
