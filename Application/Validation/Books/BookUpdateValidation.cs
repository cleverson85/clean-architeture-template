using Domain.Entities;
using FluentValidation;

namespace Application.Validation.Books;

public class BookUpdateValidation : AbstractValidator<Book>
{
    public BookUpdateValidation()
    {
        ValidateTitle();
    }

    public void ValidateTitle()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Title.");
    }
}
