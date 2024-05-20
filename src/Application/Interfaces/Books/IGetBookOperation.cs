using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Core.Interfaces;

namespace Application.Interfaces.Books;

public interface IGetBookOperation : ICoreBaseServiceAsync<GetBookRequest, GetBookResponse>
{ }
