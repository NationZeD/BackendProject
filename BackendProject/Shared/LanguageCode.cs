namespace BackendProject.Shared;

public record LanguageCode(string Code, string Name)
{
    public const string EnglishCode = "en-Us";
    public const string GeorgianCode = "ka-Geo";
    public const string AzerbaijaniCode = "az-Aze";

    public const string English = "English";
    public const string Georgian = "Georgian";
    public const string Azerbaijani = "Azerbaijani";

    public static IEnumerable<LanguageCode> GetLanguages()
    {
        yield return new LanguageCode(EnglishCode, English);
        yield return new LanguageCode(GeorgianCode, Georgian);
        yield return new LanguageCode(AzerbaijaniCode, Azerbaijani);
    }
}