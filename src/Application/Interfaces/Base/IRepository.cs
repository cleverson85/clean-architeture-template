using Domain;

namespace Application.Interfaces.Base;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
}
