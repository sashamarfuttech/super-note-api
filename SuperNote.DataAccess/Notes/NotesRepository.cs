using Microsoft.EntityFrameworkCore;
using Optional;
using SuperNote.DataAccess.DataAccess;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Notes;

public class NotesRepository : Repository<Note>, INotesRepository
{
    public NotesRepository(SuperNoteContext dbContext) 
        : base(dbContext)
    {
    }
    
    public async Task<Option<Note>> GetByIdAsync(NoteId noteId)
    {
        var note = await DbContext.Notes.SingleOrDefaultAsync(n => n.Id == noteId);
        return note.SomeNotNull();
    }
}