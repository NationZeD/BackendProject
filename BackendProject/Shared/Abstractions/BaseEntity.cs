using System.ComponentModel.DataAnnotations;

namespace BackendProject.Shared.Abstractions;

public abstract class BaseEntity<TEntityId> : IBaseEntity where TEntityId : BaseEntityId
{
    [Key] public TEntityId Id { get; private set; }
    [Timestamp] public byte[] Version { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = NormalizedTime.Now;
    private readonly List<IDomainEvent> _events;

    protected BaseEntity()
    {
        _events = new List<IDomainEvent>();
    }

    public BaseEntity(TEntityId id)
    {
        Id = id;
        _events = new List<IDomainEvent>();
    }

    public void ClearEvents()
    {
        _events?.Clear();
    }

    protected void RaiseEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> Events
    {
        get
        {
            var items = _events?.AsReadOnly();

            return items;
        }
    }
}