using Domain.Dto;
using Domain.Entities;
using FluentValidation.Results;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ValidationResult> AddBook(BookDto bookDto, CancellationToken cancellationToken);
    Task<ValidationResult> UpdateBook(BookDto bookDto, CancellationToken cancellationToken);
    Task DeleteBook(Guid id, CancellationToken cancellationToken);
    Task<BookDto> GetBook(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken);
}
