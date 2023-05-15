namespace Yarp.DynamicRouting.Core.Common.Helpers;
public static class EnumHelper
{
    public static string GetEnumDisplayName<TEnum>(TEnum enumValue)
        where TEnum : Enum
    {
        return enumValue.ToString();
    }

    public static TEnum? ParseEnumValue<TEnum>(string enumString) where TEnum : struct, IConvertible
    {
        TEnum enumValue;
        Enum.Parse(typeof(TEnum), enumString);
        if (Enum.TryParse<TEnum>(enumString, out enumValue))
        {
            return enumValue;
        }
        return null;
    }
}