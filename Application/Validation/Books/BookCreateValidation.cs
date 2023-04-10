namespace Application.Validation.Books;

public class BookCreateValidation : BookValidation
{
    public BookCreateValidation()
    {
        ValidateAuthor();
        ValidateTitle();
    }
}
