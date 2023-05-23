namespace Yarp.DynamicRouting.Core.Common.Models;
public class KeyValueItem
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}

public static class KeyValueItemExts
{
    public static Dictionary<string, string> ToDictionary(this IEnumerable<KeyValueItem> keyValueItems)
    {
        return keyValueItems.ToDictionary(item => item.Key!, item => item.Value ?? string.Empty);
    }
    public static IEnumerable<KeyValueItem> ToKeyValueItems(this Dictionary<string, string> dictionary)
    {
        return dictionary.Select(x => new KeyValueItem { Key = x.Key, Value = x.Value });
    }
}