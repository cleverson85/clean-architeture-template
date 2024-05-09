using Application.Response;
using Domain.Entities;

namespace Application.Mappers;

public static class BookMap
{
    public static BookResponse Map(this Book book)
    {
        if (book == null)
        {
            return new BookResponse();
        }

        return new BookResponse()
        {
            Book = book
        };
    }
}
