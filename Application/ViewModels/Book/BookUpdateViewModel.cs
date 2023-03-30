using Application.Validation.Books;

namespace Application.ViewModels.Book;

public class BookUpdateViewModel : BookViewModel
{
    public bool IsValid()
    {
        ValidationResult = new BookUpdateValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}