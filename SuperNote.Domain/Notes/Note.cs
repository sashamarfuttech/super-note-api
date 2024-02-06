using SuperNote.Domain.Abstractions.AggregateRoot;

namespace SuperNote.Domain.Notes;

public class Note : AggregateRoot
{
    /// <summary>
    /// Required by Entity Framework
    /// </summary>
    private Note()
    {
    }
    
    public Note(NoteText noteText, DateTime lastModified)
    {
        Id = Guid.NewGuid();
        NoteText = noteText;
        LastModified = lastModified;
        
        RaiseDomainEvent(new NoteCreatedDomainEvent(Id));
    }

    public NoteId Id { get; }
    public NoteText NoteText { get; }
    public DateTime LastModified { get; }
}