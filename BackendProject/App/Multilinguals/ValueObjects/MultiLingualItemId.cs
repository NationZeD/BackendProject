using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Multilinguals.ValueObjects;

public record MultiLingualItemId(Guid Value) : BaseEntityId(Value)
{
    public static MultiLingualItemId GetNewInstance() => new MultiLingualItemId(Guid.NewGuid());
}