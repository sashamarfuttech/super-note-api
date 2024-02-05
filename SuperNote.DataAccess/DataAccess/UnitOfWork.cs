using MediatR;
using System.Collections.Generic;
using System.Linq;
using SuperNote.Domain.SharedKernel.AggregateRoot;
using SuperNote.Domain.SharedKernel.DomainEvents;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.DataAccess.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly IPublisher _publisher;

    private readonly SuperNoteContext _context;

    public UnitOfWork(
        IPublisher publisher,
        SuperNoteContext context)
    {
        _publisher = publisher;
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = GetDomainEntities(_context);
        var domainEvents = GetDomainEvents(domainEntities);

        await _context.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
        
        domainEntities.ForEach(d => d.ClearDomainEvents());

        List<IAggregateRoot> GetDomainEntities(SuperNoteContext context) =>
            context
                .ChangeTracker
                .Entries<IAggregateRoot>()
                .Select(e => e.Entity)
                .ToList();

        List<IDomainEvent> GetDomainEvents(List<IAggregateRoot> entities) =>
            domainEntities
                .Where(e => e.DomainEvents.Any())
                .SelectMany(e => e.DomainEvents)
                .ToList();
    }
}