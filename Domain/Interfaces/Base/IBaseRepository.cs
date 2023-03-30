namespace Domain.Interfaces.Base;

public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
{
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}
