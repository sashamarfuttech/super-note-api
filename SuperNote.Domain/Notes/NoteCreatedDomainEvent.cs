using SuperNote.Domain.Abstractions.DomainEvents;

namespace SuperNote.Domain.Notes;

public record NoteCreatedDomainEvent(NoteId NoteId) : IDomainEvent;