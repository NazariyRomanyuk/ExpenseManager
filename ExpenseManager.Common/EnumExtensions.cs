using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExpenseManager.Common;

public sealed record EnumWithName<TEnum>(string Name, TEnum Value) where TEnum : struct, Enum;
public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name is null) return value.ToString();
        var field = type.GetField(name);
        var display = field?.GetCustomAttributes<DisplayAttribute>();
        
        return display?.FirstOrDefault()?.Name ?? name;
    }

    public static EnumWithName<TEnum> GetEnumWithName<TEnum>(this TEnum value) where TEnum : struct, Enum
    {
        return new EnumWithName<TEnum>(value.GetDisplayName(), value);
    }

    public static EnumWithName<TEnum>[] GetValuesWithNames<TEnum>() where TEnum : struct, Enum
    {
        var values = Enum.GetValues<TEnum>();
        var valuesWithNames = new EnumWithName<TEnum>[values.Length];
        for (var i = 0; i < values.Length; i++)
        {
            valuesWithNames[i] = values[i].GetEnumWithName();
        }
        return valuesWithNames;
    }
}