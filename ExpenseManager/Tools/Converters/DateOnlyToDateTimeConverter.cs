using System.Globalization;

namespace ExpenseManager.Tools.Converters;

public class DateOnlyToDateTimeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return ((DateOnly)value).ToDateTime(TimeOnly.MinValue);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return DateOnly.FromDateTime((DateTime)value);
    }
}