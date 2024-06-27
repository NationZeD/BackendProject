using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Multilinguals.ValueObjects;

public record MultiLingualId(Guid Value) : BaseEntityId(Value)
{
    public static MultiLingualId GetNewInstance() => new MultiLingualId(Guid.NewGuid());
}