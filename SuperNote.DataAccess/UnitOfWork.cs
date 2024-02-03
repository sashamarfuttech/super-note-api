using SuperNote.DataAccess.Database;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly SuperNoteContext _context;

    public UnitOfWork(SuperNoteContext context) => _context = context;
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}