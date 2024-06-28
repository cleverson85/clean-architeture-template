namespace Domain.Interfaces.Base;

public interface IBaseRepository<TEntity> where TEntity : Entity, IAggregateRoot
{
    Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
}
