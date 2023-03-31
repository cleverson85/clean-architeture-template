using Domain.Entities;

namespace Domain.Validation.Books;

public class BookUpdateValidation : BookValidation<Book>
{
    public BookUpdateValidation()
    {
        ValidateTitle();
    }
}
