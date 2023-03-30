using Application.ViewModels.Book;
using FluentValidation;

namespace Application.Validation.Books;

public class BookValidation<T> : AbstractValidator<T> where T : BookViewModel
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
}
