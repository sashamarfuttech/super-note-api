using Microsoft.EntityFrameworkCore;
using SuperNote.DataAccess.Database;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Repositories;

public class NotesRepository : Repository<Note>, INotesRepository
{
    public NotesRepository(SuperNoteContext dbContext) 
        : base(dbContext)
    {
    }
    
    public async Task<Note> GetByIdAsync(NoteId noteId)
    {
        var note = await DbContext.Notes.SingleOrDefaultAsync(n => n.Id == noteId);
        return note;
    }
}