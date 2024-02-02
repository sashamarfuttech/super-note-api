using Microsoft.EntityFrameworkCore;
using SuperNote.DataAccess.Database;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Repositories;

public class NotesRepository : INotesRepository
{
    private SuperNoteContext _dbContext;
    
    public NotesRepository(SuperNoteContext dbContext) => _dbContext = dbContext;
    
    public async Task<IReadOnlyList<Note>> GetNotesAsync()
    {
        var notes = await _dbContext.Notes.ToListAsync();
        return notes;
    }

    public async Task AddAsync(Note note)
    {
        await _dbContext.Notes.AddAsync(note);
    }
}