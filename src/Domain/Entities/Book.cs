using Domain.Enums;

namespace Domain.Entities;

public class Book : Entity, IAggregateRoot
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public BookType Type { get; set; }
}
