namespace Application.Validators.Books;

public class BookCreateValidation : BookValidation
{
    public BookCreateValidation()
    {
        ValidateAuthor();
        ValidateTitle();
    }
}
