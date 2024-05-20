using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Core.Interfaces;

namespace Application.Interfaces.Books;

public interface IUpdateBookOperation : ICoreBaseServiceAsync<UpdateBookRequest, UpdateBookResponse>
{
}
