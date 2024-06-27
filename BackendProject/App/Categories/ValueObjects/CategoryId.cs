using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Categories.ValueObjects;

public record CategoryId : BaseEntityId
{
    public CategoryId()
    {
    }

    public CategoryId(Guid value) : base(value)
    {
    }

    public static CategoryId New => new CategoryId(Guid.NewGuid());
}