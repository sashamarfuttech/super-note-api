using SuperNote.Domain.SharedKernel.AggregateRoot;

namespace SuperNote.Domain.Notes;

public class Note : AggregateRoot
{
    public Note(string text)
    {
        Id = new NoteId(Guid.NewGuid());
        Text = text;
    }

    public NoteId Id { get; set; }
    
    public string Text { get; } = string.Empty;

    public DateTime LastModified { get; }
}