using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Messaging;
using System.Reflection;

namespace Infrastructure.Data.Contexts;

public class Context : DbContext, IUnitOfWork
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Book> Book { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        var success = await SaveChangesAsync() > 0;
        return success;
    }
}

