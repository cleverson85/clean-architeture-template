using Domain;

namespace Application.Interfaces.Base;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity, IAggregateRoot
{
    Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}
