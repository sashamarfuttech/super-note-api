namespace SuperNote.Domain.Notes;

public record struct NoteId(Guid Value)
{
    public static implicit operator Guid(NoteId noteId) => noteId.Value;
    public static implicit operator NoteId(Guid guid) => new (guid);
}