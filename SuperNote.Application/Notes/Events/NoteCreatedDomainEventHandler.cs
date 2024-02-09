using MediatR;
using Microsoft.Extensions.Logging;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Events;

public sealed class NoteCreatedDomainEventHandler : INotificationHandler<NoteCreatedDomainEvent>
{
    private readonly ILogger<NoteCreatedDomainEventHandler> _logger;

    public NoteCreatedDomainEventHandler(ILogger<NoteCreatedDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(NoteCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogWarning("NoteCreatedDomainEventHandler is intentionally left blank.");
        
        await Task.CompletedTask;
    }
}