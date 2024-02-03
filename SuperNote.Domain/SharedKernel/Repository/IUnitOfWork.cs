namespace SuperNote.Domain.SharedKernel.Repository;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}