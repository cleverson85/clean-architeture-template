using Domain.Entities;
using FluentValidation;

namespace Application.Validation.Books;

public class BookUpdateValidation : BookValidation
{
    public BookUpdateValidation()
    {
        ValidateObject();
    }
}
