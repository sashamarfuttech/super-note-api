namespace SuperNote.Domain.SharedKernel.DataAccess;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}