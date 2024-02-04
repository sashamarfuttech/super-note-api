using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.Domain.Notes;

public interface INotesRepository : IRepository<Note>
{
    Task<Note> GetByIdAsync(NoteId noteId);
}