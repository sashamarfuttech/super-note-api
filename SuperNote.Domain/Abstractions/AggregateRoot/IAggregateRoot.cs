using SuperNote.Domain.Abstractions.DomainEvents;

namespace SuperNote.Domain.Abstractions.AggregateRoot;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    
    void ClearDomainEvents();
}