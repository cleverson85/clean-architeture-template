using Domain.Validation.Books;

namespace Domain.Entities;

public class Book : BaseEntity, IAggregateRoot
{
    public string Author { get; set; }
    public string Title { get; set; }

    public bool ValidateIsValid()
    {
        ValidationResult = new BookCreateValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public bool UpdateIsValid()
    {
        ValidationResult = new BookUpdateValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
