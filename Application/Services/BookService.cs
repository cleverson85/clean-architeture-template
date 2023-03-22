using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using FluentValidation.Results;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public BookService(IMapper mapper, IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<ValidationResult> AddBook(BookViewModel entity, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(entity);

        if (!book.IsValid())
        {
            return book.ValidationResult;
        }

        await _bookRepository.SaveAsync(book, cancellationToken);

        return await _bookRepository.UnitOfWork.Commit();
    }

    public async Task<ValidationResult> DeleteBook(BookViewModel entity, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(entity);
        await _bookRepository.DeleteAsync(book, cancellationToken);

        return await _bookRepository.UnitOfWork.Commit();
    }

    public async Task<BookViewModel> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<BookViewModel>(book);
    }

    public async Task<IEnumerable<BookViewModel>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BookViewModel>>(books);
    }

    public async Task<ValidationResult> UpdateBook(BookViewModel entity, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(entity);
        await _bookRepository.UpdateAsync(book, cancellationToken);

        return await _bookRepository.UnitOfWork.Commit();
    }
}
