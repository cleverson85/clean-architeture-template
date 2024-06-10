using Application.Core;
using Domain.Entities;

namespace Core.Contracts.Request.Books;

public class UpdateBookRequest : CoreOperationRequest
{
    public Book Book { get; set; } = new Book();
}
