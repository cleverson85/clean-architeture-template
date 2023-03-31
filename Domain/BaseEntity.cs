using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    [NotMapped]
    public ValidationResult ValidationResult { get; set; }
}
