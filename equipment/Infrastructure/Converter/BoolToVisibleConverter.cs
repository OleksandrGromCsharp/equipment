using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Перетворення визначеності видимості об'єкта
    /// </summary>
    internal class BoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value) return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
