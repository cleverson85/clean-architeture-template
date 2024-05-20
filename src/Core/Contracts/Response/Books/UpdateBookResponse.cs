using Domain.Entities;

namespace Core.Contracts.Response.Books
{
    public class UpdateBookResponse : CoreOperationResponse
    {
        public Book? Book { get; set; }
    }
}
