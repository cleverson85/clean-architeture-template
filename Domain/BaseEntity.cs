using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    [NotMapped]
    public ValidationResult ValidationResult { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
