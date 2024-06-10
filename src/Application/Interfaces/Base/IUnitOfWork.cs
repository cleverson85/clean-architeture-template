using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces.Base;

public interface IUnitOfWork
{
    DbContext Context { get; }
    IBookRepository BookRepository { get; }
    Task<IDbContextTransaction> BeginTransacionAsync();
    Task SaveChangesAsync();
    Task RollBackTransactionAsync();
}
