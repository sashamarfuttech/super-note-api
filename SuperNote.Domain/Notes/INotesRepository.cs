namespace SuperNote.Infrastructure.Notes;

public interface INotesRepository
{
    Task<Note> GetNoteAsync(NoteId noteId);
}

public class NotesRepository : INotesRepository
{
    public Task<Note> GetNoteAsync(NoteId noteId)
    {
        return Task.FromResult(new Note());
    }
}