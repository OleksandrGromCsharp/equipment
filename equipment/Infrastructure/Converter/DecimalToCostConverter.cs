using System.Globalization;
using System.Windows.Data;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Перетворення визначеності видимості об'єкта
    /// </summary>
    internal class DecimalToCostConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() is null)
                return default;

            return ((decimal)value).ToString("C2", new CultureInfo("uk-UA"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string costString = value.ToString().Replace(".", ",").Replace(" ", "").Replace("₴", "");
            _ = decimal.TryParse(costString, out decimal cost);
            return cost;
        }
    }
}
