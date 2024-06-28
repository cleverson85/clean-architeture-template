using Application.Core.Contract;
using Application.Interfaces.Messaging;

namespace Application.Books.Queries.GetById;

public sealed record GetBookByIdQuery(Guid Id) : IQuery<CoreOperationResponse>;
