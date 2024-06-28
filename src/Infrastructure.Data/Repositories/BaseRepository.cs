using Domain;
using Domain.Interfaces.Base;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, IAggregateRoot
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly Context _context;

    public BaseRepository(Context context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity!);
        return await Task.FromResult(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken) => await _dbSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }
}
