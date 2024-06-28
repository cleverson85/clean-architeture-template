using Application.Exceptions.Base;

namespace Application.Exceptions;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(Guid id) 
        : base("Book.NotFound", $"The book with id {id} was not found.")
    { }
}
