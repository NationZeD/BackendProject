using BackendProject.App.Multilinguals.ValueObjects;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Multilinguals.Entities;

public class MultiLingualItem : BaseEntity<MultiLingualItemId>
{
    public string Code { get; private set; }
    public string? Value { get; private set; }
    public MultiLingualId MultiLingualId { get; private set; }

    protected MultiLingualItem()
    {
    }

    public MultiLingualItem(MultiLingualItemId id, MultiLingualId multiLingualId, string code, string value) : base(id)
    {
        Code = code;
        Value = value;
        MultiLingualId = multiLingualId;
    }

    internal void ChangeValue(string value)
    {
        Value = value;
    }
}