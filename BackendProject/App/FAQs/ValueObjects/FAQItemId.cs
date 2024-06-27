using BackendProject.Shared.Abstractions;

namespace BackendProject.App.FAQs.ValueObjects;

public record FAQItemId : BaseEntityId
{
    public FAQItemId()
    {
    }

    public FAQItemId(Guid value) : base(value)
    {
    }

    public static FAQItemId New => new FAQItemId(Guid.NewGuid());
}