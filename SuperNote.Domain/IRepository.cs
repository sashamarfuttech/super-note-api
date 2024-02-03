namespace SuperNote.Domain;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetALl();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}