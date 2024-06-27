using BackendProject.App.Multilinguals.Entities;
using BackendProject.Shared;

namespace BackendProject.App.Multilinguals.Dtos;

public class MultiLingualInput
{
    public List<MultilingualInputItem> Items { get; set; }

    public void Read(Multilingual source)
    {
        foreach (var item in source.Items)
        {
            var inputItem = Items.FirstOrDefault(x => x.LanguageCode == item.Code);
            inputItem.Value = item.Value;
        }
    }

    public void Write(Multilingual destination)
    {
        foreach (var item in Items)
        {
            destination.Set(item.LanguageCode, item.Value);
        }
    }

    public static MultiLingualInput GetNewInstance()
    {
        var input = new MultiLingualInput() { Items = new List<MultilingualInputItem>() };
        var languages = LanguageCode.GetLanguages();
        foreach (var language in languages)
        {
            input.Items.Add(new MultilingualInputItem()
            {
                LanguageCode = language.Code,
                LanguageName = language.Name
            });
        }

        return input;
    }
}