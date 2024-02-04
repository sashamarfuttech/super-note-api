using Microsoft.EntityFrameworkCore;
using Optional;
using SuperNote.DataAccess.Database;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Repositories;

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