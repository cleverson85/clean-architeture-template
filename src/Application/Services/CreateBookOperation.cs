using Application.Interfaces;
using Application.Mappers;
using Application.Response;
using Application.Validation.Books;
using Core.Contracts;
using Core.Services;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class CreateBookOperation : CoreOperationAsync<BookRequest, BookResponse>, IBookOperation
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CoreOperationAsync<BookRequest, BookResponse>> _logger;

    public CreateBookOperation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<BookRequest, BookResponse>> logger) : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    protected override async Task<BookResponse> ProcessOperationAsync(BookRequest request, CancellationToken cancellationToken)
    {
        Book book = request;
        var result = await _unitOfWork.BookRepository.SaveAsync(book, cancellationToken);
        return result.Map();
    }

    protected override async Task<ValidationResult> ValidateAsync(BookRequest request, CancellationToken cancellationToken)
    {
        var validator = new BookCreateValidation();
        return await validator.ValidateAsync(request, cancellationToken);
    }

    //public async Task<ValidationResult> AddBook(BookDto bookDto, CancellationToken cancellationToken)
    //{
    //    Book book = bookDto;

    //    var validator = new BookCreateValidation();
    //    var result = validator.Validate(book);

    //    if (result.IsValid)
    //    {
    //        await _bookRepository.SaveAsync(book, cancellationToken);
    //    }

    //    return result;
    //}

    //public async Task<Book> DeleteBook(Guid id, CancellationToken cancellationToken)
    //{
    //    var book = await _bookRepository.GetAsync(id, cancellationToken) ?? throw new BookNotFoundException("Book not found.");
    //    await _bookRepository.DeleteAsync(book!, cancellationToken);

    //    return book;
    //}

    //public async Task<BookDto> GetBook(Guid id, CancellationToken cancellationToken)
    //{
    //    var book = await _bookRepository.GetAsync(id, cancellationToken);
    //    BookDto bookDto = book;

    //    return bookDto;
    //}

    //public async Task<IEnumerable<Book>> GetBooks(CancellationToken cancellationToken)
    //{
    //    var books = await _bookRepository.GetAllAsync(cancellationToken);
    //    return books;
    //}

    //public async Task<ValidationResult> UpdateBook(BookDto bookDto, CancellationToken cancellationToken)
    //{
    //    _ = await _bookRepository.GetAsync(bookDto.Id, cancellationToken) ?? throw new BookNotFoundException("Book not found.");
    //    Book book = bookDto;

    //    var validator = new BookUpdateValidation();
    //    var result = validator.Validate(book);

    //    if (result.IsValid)
    //    {
    //        await _bookRepository.UpdateAsync(book, cancellationToken);
    //        await _bookRepository.UnitOfWork.CommitTransactionAsync();
    //    }

    //    return result;
    //}
}
