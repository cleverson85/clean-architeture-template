using Application.Exceptions;
using Application.Interfaces;
using Application.Validation.Books;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.Repository;
using FluentValidation.Results;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ValidationResult> AddBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        Book book = bookDto;

        var validator = new BookCreateValidation();
        var result = validator.Validate(book);

        if (result.IsValid)
        {
            await _bookRepository.SaveAsync(book, cancellationToken);
            await _bookRepository.UnitOfWork.Commit();
        }

        return result;
    }

    public async Task<Book> DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(id, cancellationToken) ?? throw new BookNotFoundException("Book not found.");
        await _bookRepository.DeleteAsync(book!, cancellationToken);
        await _bookRepository.UnitOfWork.Commit();

        return book;
    }

    public async Task<BookDto> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(id, cancellationToken);
        BookDto bookDto = book;

        return bookDto;
    }

    public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);
        return books;
    }

    public async Task<ValidationResult> UpdateBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        _ = await _bookRepository.GetAsync(bookDto.Id, cancellationToken) ?? throw new BookNotFoundException("Book not found.");
        Book book = bookDto;

        var validator = new BookUpdateValidation();
        var result = validator.Validate(book);

        if (result.IsValid)
        {
            await _bookRepository.UpdateAsync(book, cancellationToken);
            await _bookRepository.UnitOfWork.Commit();
        }

        return result;
    }
}
