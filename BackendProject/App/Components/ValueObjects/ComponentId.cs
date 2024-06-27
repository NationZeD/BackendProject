using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Components.ValueObjects;

public record ComponentId : BaseEntityId
{
    public ComponentId()
    {
    }

    public ComponentId(Guid value) : base(value)
    {
    }

    public static ComponentId New => new ComponentId(Guid.NewGuid());
}