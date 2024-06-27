using System.Text;

namespace BackendProject.Shared.Extensions;

public static class QueryExtensions
{
    public static string ToQuerySearchText(this string text)
    {
        var sb = new StringBuilder();
        if (string.IsNullOrEmpty(text))
            return null;

        var items = text.Split(' ').ToList();
        if (items.Count == 1)
        {
            return $"\"{text}\"";
        }

        foreach (var item in items)
        {
            if (!string.IsNullOrEmpty(item))
            {
                sb.Append($"\"{item}*\"");
            }

            if (items.IndexOf(item) != items.Count - 1)
            {
                sb.Append(" NEAR ");
            }
        }

        return sb.ToString();
    }
}