using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExpenseManager.Common;

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
}