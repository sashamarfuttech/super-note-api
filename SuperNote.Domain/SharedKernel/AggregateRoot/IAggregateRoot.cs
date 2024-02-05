using SuperNote.Domain.SharedKernel.DomainEvents;

namespace SuperNote.Domain.SharedKernel.AggregateRoot;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    
    void ClearDomainEvents();
}