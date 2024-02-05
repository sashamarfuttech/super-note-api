using SuperNote.Domain.SharedKernel.DomainEvents;

namespace SuperNote.Domain.Notes;

public record NoteCreatedDomainEvent(Guid NoteId) : IDomainEvent;