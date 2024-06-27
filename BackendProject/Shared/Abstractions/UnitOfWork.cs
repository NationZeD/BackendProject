using BackendProject.Shared.Persistence.Data;
using MassTransit;
using MediatR;

namespace BackendProject.Shared.Abstractions;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    private readonly IPublisher _publisher;
    private readonly IBus _bus;

    public UnitOfWork(ApplicationDbContext db, IPublisher publisher, IBus bus)
    {
        _db = db;
        _publisher = publisher;
        _bus = bus;
    }

    public async Task<int> SaveAsync()
    {
        var result = await _db.SaveChangesAsync();
        await PublishDomainEventsAsync();

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var entities = _db.ChangeTracker
            .Entries<IBaseEntity>()
            .Select(entry => entry.Entity)
            .ToList();
        var domainEvents = new List<object>();
        foreach (var baseEntity in entities)
        {
            domainEvents.AddRange(baseEntity.Events.Select(x => x.GetValue()));
            baseEntity.ClearEvents();
        }

        await _bus.PublishBatch(domainEvents);
    }
}