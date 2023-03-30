using Application.Interfaces;
using Application.ViewModels.Book;
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

    public async Task<ValidationResult> AddBook(BookCreateViewModel entity, CancellationToken cancellationToken)
    {
        if (!entity.IsValid())
        {
            return entity.ValidationResult;
        }

        var book = _mapper.Map<Book>(entity);

        await _bookRepository.SaveAsync(book, cancellationToken);
        await _bookRepository.UnitOfWork.Commit();

        return entity.ValidationResult;
    }

    public async Task DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        await _bookRepository.DeleteAsync(id, cancellationToken);
        await _bookRepository.UnitOfWork.Commit();
    }

    public async Task<BookViewModel> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<BookCreateViewModel>(book);
    }

    public async Task<IEnumerable<BookViewModel>> GetBooks(CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BookCreateViewModel>>(books);
    }

    public async Task<ValidationResult> UpdateBook(BookUpdateViewModel entity, CancellationToken cancellationToken)
    {
        if (!entity.IsValid())
        {
            return entity.ValidationResult;
        }

        var book = _mapper.Map<Book>(entity);

        await _bookRepository.UpdateAsync(book, cancellationToken);
        await _bookRepository.UnitOfWork.Commit();

        return entity.ValidationResult;
    }
}
