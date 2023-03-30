using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels;

public class BaseViewModel
{
    [Key]
    public Guid Id { get; set; }
    [NotMapped]
    public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
}
