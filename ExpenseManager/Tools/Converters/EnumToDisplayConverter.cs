using System.Globalization;
using ExpenseManager.Common;


namespace ExpenseManager.Tools.Converters;

public class EnumToDisplayConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) return string.Empty;
        return value is not Enum enumValue ? value.ToString() : enumValue.GetDisplayName();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}