using Domain.Interfaces.Base;
using Domain.Interfaces.Repository;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    public DbContext Context { get; private set;  }
    public IBookRepository BookRepository { get; private set;  }

    public UnitOfWork(Context context, IBookRepository bookRepository)
    {
        Context = context;
        BookRepository = bookRepository;
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransacionAsync()
    {
        return await Context.Database.BeginTransactionAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await Context.Database.RollbackTransactionAsync();
    }
}
