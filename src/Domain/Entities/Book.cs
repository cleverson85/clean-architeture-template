using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book : BaseEntity, IAggregateRoot
{
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
}
