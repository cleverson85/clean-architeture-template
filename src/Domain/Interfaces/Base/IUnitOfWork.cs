using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Interfaces.Base;

public interface IUnitOfWork
{
    DbContext Context { get; }
    IBookRepository BookRepository { get; }
    Task<IDbContextTransaction> BeginTransacionAsync();
    Task SaveChangesAsync();
    Task RollBackTransactionAsync();
}
