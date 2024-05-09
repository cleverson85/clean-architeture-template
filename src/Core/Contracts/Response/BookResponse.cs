using Core;
using Domain.Entities;

namespace Application.Response;

public class BookResponse : CoreOperationResponse
{
    public Book? Book { get; set; }
}
