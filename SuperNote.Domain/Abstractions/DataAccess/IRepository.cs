using SuperNote.Domain.Abstractions.Aggregates;

namespace SuperNote.Domain.Abstractions.DataAccess;

public interface IRepository<TEntity> where TEntity : AggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetALl();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}