using Domain.Entities;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public async Task Commit()
    {
        await SaveChangesAsync();
    }
}

