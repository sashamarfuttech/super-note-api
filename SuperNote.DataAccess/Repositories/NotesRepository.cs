using SuperNote.DataAccess.Database;
using SuperNote.Domain.Notes;

namespace SuperNote.DataAccess.Repositories;

public class NotesRepository : Repository<Note>, INotesRepository
{
    public NotesRepository(SuperNoteContext dbContext) 
        : base(dbContext)
    {
    }
    
    //TODO: specific notes queries here
}