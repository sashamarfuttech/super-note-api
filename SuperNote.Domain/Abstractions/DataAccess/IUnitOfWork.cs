namespace SuperNote.Domain.Abstractions.DataAccess;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}