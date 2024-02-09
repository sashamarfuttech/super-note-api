using SuperNote.Domain.Abstractions.Aggregates;

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
        Id = NoteId.New();
        NoteText = noteText;
        LastModified = lastModified;
        
        RaiseDomainEvent(new NoteCreatedDomainEvent(Id));
    }

    public NoteId Id { get; }
    public NoteText NoteText { get; }
    public DateTime LastModified { get; }
}