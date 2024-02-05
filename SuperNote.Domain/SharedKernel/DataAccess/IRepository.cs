using SuperNote.Domain.SharedKernel.AggregateRoot;

namespace SuperNote.Domain.SharedKernel.Repository;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetALl();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}