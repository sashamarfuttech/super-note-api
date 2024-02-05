using SuperNote.Domain.SharedKernel.AggregateRoot;

namespace SuperNote.Domain.Notes;

public class Note : AggregateRoot
{
    public Note()
    {
    }
    
    public Note(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
        
        RaiseDomainEvent(new NoteCreatedDomainEvent(Id));
    }

    public NoteId Id { get; }
    
    public string Text { get; } = string.Empty;

    public DateTime LastModified { get; }
}