using MediatR;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Events;

public sealed class NoteCreatedDomainEventHandler : INotificationHandler<NoteCreatedDomainEvent>
{
    public async Task Handle(NoteCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // TODO:
        await Task.CompletedTask;
    }
}