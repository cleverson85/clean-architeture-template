using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(Guid id) 
        : base($"The book with id {id} was not found.")
    { }
}
