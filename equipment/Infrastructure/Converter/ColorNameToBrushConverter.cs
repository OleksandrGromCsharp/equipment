using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Перетворення кольору із формата "ff0000" в колір типу System.Windows.Media.Brush
    /// </summary>
    internal class ColorNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString($"#{value.ToString().ToUpper()}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
