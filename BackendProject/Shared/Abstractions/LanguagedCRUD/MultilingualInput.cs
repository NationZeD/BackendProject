using BackendProject.App.Multilinguals.Entities;

namespace BackendProject.Shared.Abstractions.LanguagedCRUD;

public class MultilingualInput
{
    public List<MultilingualInputItem> Items { get; set; }

    public MultilingualInput()
    {
        Items = new List<MultilingualInputItem>();
        foreach (var languageCode in LanguageCode.GetLanguages())
        {
            Items.Add(new MultilingualInputItem
            {
                Value = null,
                LanguageName = languageCode.Name,
                LanguageCode = languageCode.Code
            });
        }
    }

    public void Read(Multilingual source)
    {
        foreach (var multiLingualItem in source.Items)
        {
            var item = Items.FirstOrDefault(x => x.LanguageCode == multiLingualItem.Code);
            if (item != null)
            {
                item.Value = multiLingualItem.Value;
            }
        }
    }

    public void Write(Multilingual destination)
    {
        foreach (var item in Items)
        {
            destination.Set(item.LanguageCode, item.Value);
        }
    }

    public static MultilingualInput Parse(Multilingual source)
    {
        var instance = new MultilingualInput();
        instance.Read(source);
        return instance;
    }
}