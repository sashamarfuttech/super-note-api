namespace SuperNote.Infrastructure.Notes;

public record struct NoteId(Guid Id)
{
    public static implicit operator Guid(NoteId noteId) => noteId.Id;
    public static implicit operator NoteId(Guid guid) => new (guid);
}