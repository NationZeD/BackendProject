namespace BackendProject.Shared.Abstractions;

public record BaseEntityId
{
    public Guid Value { get; private set; }

    public BaseEntityId(Guid value)
    {
        Value = value;
    }

    public BaseEntityId()
    {
    }

    public static T Parse<T>(Guid value) where T : BaseEntityId, new()
    {
        return new T() { Value = value };
    }
}