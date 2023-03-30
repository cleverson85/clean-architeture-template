using Application.ViewModels.Book;

namespace Application.Validation.Books;

public class BookCreateValidation : BookValidation<BookCreateViewModel>
{
    public BookCreateValidation()
    {
        ValidateAuthor();
        ValidateTitle();
    }
}
