using Optional;
using SuperNote.Domain.SharedKernel.DataAccess;

namespace SuperNote.Domain.Notes;

public interface INotesRepository : IRepository<Note>
{
    Task<Option<Note>> GetByIdAsync(NoteId noteId);
}