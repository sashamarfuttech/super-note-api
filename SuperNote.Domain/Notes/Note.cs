namespace SuperNote.Infrastructure.Notes;

public class Note
{
    public Note()
    {
    }
    
    public Note(string text)
    {
        Id = new NoteId(Guid.NewGuid());
        Text = text;
    }
    
    public NoteId Id { get; }

    public string Text { get; } = string.Empty;

    public DateTime LastModified { get; }
}