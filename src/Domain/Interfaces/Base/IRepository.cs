namespace Domain.Interfaces.Base;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}
