using System.Globalization;
using ExpenseManager.Common;


namespace ExpenseManager.Tools;

public class EnumToDisplayConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) return string.Empty;
        if (value is not Enum enumValue) return value.ToString();
        return enumValue.GetDisplayName();

    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}