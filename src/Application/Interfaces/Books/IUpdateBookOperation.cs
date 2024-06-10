using Application.Core.Interfaces;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;

namespace Application.Interfaces.Books;

public interface IUpdateBookOperation : ICoreBaseServiceAsync<UpdateBookRequest, UpdateBookResponse>
{ }
