using Domain.Dto;

namespace Domain.Entities;

public class Book : BaseEntity, IAggregateRoot
{
    public string Author { get; set; }
    public string Title { get; set; }

    public static implicit operator BookDto(Book book) => new()
    {
        Author = book.Author,
        Title = book.Title,
        Id = book.Id
    };
}
