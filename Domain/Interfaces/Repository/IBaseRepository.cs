using NetDevPack.Data;
using NetDevPack.Domain;

namespace Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
{
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}
