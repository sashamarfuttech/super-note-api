using SuperNote.Domain.Abstractions.AggregateRoot;

namespace SuperNote.Domain.Abstractions.DataAccess;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetALl();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}