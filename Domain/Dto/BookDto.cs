using Domain.Entities;

namespace Domain.Dto;

public class BookDto
{
    public Guid Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }

    public static implicit operator Book(BookDto bookDto) => new()
    {
        Id = bookDto.Id,
        Author = bookDto.Author,
        Title = bookDto.Title,
    };
}
