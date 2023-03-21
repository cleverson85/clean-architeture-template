using Application.ViewModels;
using FluentValidation.Results;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ValidationResult> AddBook(BookViewModel entity, CancellationToken cancellationToken);
    Task<ValidationResult> UpdateBook(BookViewModel entity, CancellationToken cancellationToken);
    Task<ValidationResult> DeleteBook(BookViewModel entity, CancellationToken cancellationToken);
    Task<BookViewModel> GetBook(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<BookViewModel>> GetBooks(CancellationToken cancellationToken);
}
