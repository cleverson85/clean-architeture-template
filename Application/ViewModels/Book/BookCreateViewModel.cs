using Application.Validation.Books;

namespace Application.ViewModels.Book;

public class BookCreateViewModel : BookViewModel
{
    public bool IsValid()
    {
        ValidationResult = new BookCreateValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}