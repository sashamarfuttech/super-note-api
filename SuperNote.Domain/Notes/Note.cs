namespace SuperNote.Infrastructure.Notes;

public class Note
{
    public NoteId Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime LastModified { get; set; }
}