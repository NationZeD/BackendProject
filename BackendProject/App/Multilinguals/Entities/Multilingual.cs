using BackendProject.App.Multilinguals.ValueObjects;
using BackendProject.Shared;
using BackendProject.Shared.Abstractions;

namespace BackendProject.App.Multilinguals.Entities;

public class Multilingual : BaseEntity<MultiLingualId>
{
    private readonly List<MultiLingualItem> _items;

    protected Multilingual()
    {
    }

    public Multilingual(MultiLingualId id, List<MultiLingualItem> items) : base(id)
    {
        _items = items;
    }

    public IReadOnlyCollection<MultiLingualItem> Items => _items.AsReadOnly();

    public string GetValue()
    {
        return _items.FirstOrDefault().Value;
    }

    public string GetValue(string code)
    {
        return _items.FirstOrDefault(x => x.Code == code)?.Value;
    }

    public void Set(string code, string value)
    {
        if (LanguageCode.GetLanguages().All(x => x.Code != code)) throw new Exception("Given language code is invalid");
        var item = GetItem(code);
        if (item == null)
        {
            Add(code, value);
            return;
        }

        item.ChangeValue(value);
    }

    private MultiLingualItem? GetItem(string code)
    {
        return _items.FirstOrDefault(x => x.Code == code);
    }

    private void Add(string code, string value)
    {
        _items.Add(new MultiLingualItem(MultiLingualItemId.GetNewInstance(), Id, code, value));
    }

    public static Multilingual GetNewInstance()
    {
        var id = new MultiLingualId(Guid.NewGuid());
        var items = new List<MultiLingualItem>();
        var languages = LanguageCode.GetLanguages();
        foreach (var language in languages)
        {
            items.Add(new MultiLingualItem(MultiLingualItemId.GetNewInstance(), id, language.Code, String.Empty));
        }

        return new Multilingual(id, items);
    }

    public static Multilingual GetNewInstance(Multilingual instance)
    {
        var id = new MultiLingualId(Guid.NewGuid());
        var items = new List<MultiLingualItem>();
        var languages = LanguageCode.GetLanguages();
        foreach (var language in languages)
        {
            var existing = instance.Items.FirstOrDefault(x => x.Code == language.Code);
            items.Add(new MultiLingualItem(new MultiLingualItemId(Guid.NewGuid()), id, language.Code, existing.Value));
        }

        return new Multilingual(id, items);
    }
}