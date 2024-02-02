namespace SuperNote.Infrastructure.Notes;

public interface INotesRepository
{
    Task<IReadOnlyList<Note>> GetNotesAsync();
    Task AddAsync(Note note);
}