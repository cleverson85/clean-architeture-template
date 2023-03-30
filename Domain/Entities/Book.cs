namespace Domain.Entities;

public class Book : BaseEntity, IAggregateRoot
{
    public string Author { get; set; }
    public string Title { get; set; }
}
