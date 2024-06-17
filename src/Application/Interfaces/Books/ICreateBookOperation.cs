using Application.Contracts.Request.Books;
using Application.Core.Interfaces;
using Core.Contracts.Response.Books;

namespace Application.Interfaces.Books;

public interface ICreateBookOperation : ICoreBaseServiceAsync<CreateBookRequest, CreateBookResponse>
{ }
