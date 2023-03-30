using Application.ViewModels.Book;
using FluentValidation.Results;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ValidationResult> AddBook(BookCreateViewModel entity, CancellationToken cancellationToken);
    Task<ValidationResult> UpdateBook(BookUpdateViewModel entity, CancellationToken cancellationToken);
    Task DeleteBook(Guid id, CancellationToken cancellationToken);
    Task<BookViewModel> GetBook(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<BookViewModel>> GetBooks(CancellationToken cancellationToken);
}
