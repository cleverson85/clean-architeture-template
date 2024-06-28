using Application.Core.Contract;
using Application.Interfaces.Messaging;

namespace Application.Books.Queries.GetAll;

public sealed record GetAllBooksQuery : IQuery<CoreOperationResponse>;
