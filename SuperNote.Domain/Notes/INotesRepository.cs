using Optional;
using SuperNote.Domain.Abstractions.DataAccess;

namespace SuperNote.Domain.Notes;

public interface INotesRepository : IRepository<Note>
{
    Task<Option<Note>> GetByIdAsync(NoteId noteId);
}