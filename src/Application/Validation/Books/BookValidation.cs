using Domain.Entities;
using FluentValidation;

namespace Application.Validation.Books;

public class BookValidation : AbstractValidator<Book>
{
    protected void ValidateAuthor()
    {
        RuleFor(c => c.Author)
               .NotEmpty()
               .WithMessage("Please ensure you have entered the Author Name.")
               .Length(2, 150)
               .WithMessage("The Author Name must have between 2 and 150 characters");
    }

    protected void ValidateTitle()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Title.");
    }

    protected void ValidateObject()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .WithMessage("Book not found to update.");
    }
}
