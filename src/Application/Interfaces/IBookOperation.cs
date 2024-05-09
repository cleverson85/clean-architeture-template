using Application.Response;
using Core.Contracts;
using Core.Interfaces;

namespace Application.Interfaces;

public interface IBookOperation : ICoreBaseServiceAsync<BookRequest, BookResponse>
{
    //Task<ValidationResult> AddBook(BookDto bookDto, CancellationToken cancellationToken);
    //Task<ValidationResult> UpdateBook(BookDto bookDto, CancellationToken cancellationToken);
    //Task<Book> DeleteBook(Guid id, CancellationToken cancellationToken);
    //Task<BookDto> GetBook(Guid id, CancellationToken cancellationToken);
    //Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken);
}
