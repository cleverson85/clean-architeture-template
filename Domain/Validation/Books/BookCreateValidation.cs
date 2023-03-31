using Domain.Entities;

namespace Domain.Validation.Books;

public class BookCreateValidation : BookValidation<Book>
{
    public BookCreateValidation()
    {
        ValidateAuthor();
        ValidateTitle();
    }
}
