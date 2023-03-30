using Application.ViewModels.Book;

namespace Application.Validation.Books;

public class BookUpdateValidation : BookValidation<BookUpdateViewModel>
{
    public BookUpdateValidation()
    {
        ValidateTitle();
    }
}
