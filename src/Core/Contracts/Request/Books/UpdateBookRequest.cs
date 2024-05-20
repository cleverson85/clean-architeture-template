using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Contracts.Request.Books;

public class UpdateBookRequest : CoreOperationRequest
{
    public Book Book { get; set; } = new Book();
}
