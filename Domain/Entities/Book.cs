using Domain.Validation.Books;
using FluentValidation.Results;

namespace Domain.Entities;

public class Book : BaseEntity, IAggregateRoot
{
    public string Author { get; set; }
    public string Title { get; set; }

    public bool IsValid()
    {
        ValidationResult = new BookCreateValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
