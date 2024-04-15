using System.Globalization;
using System.Windows.Data;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Видалення стандартного значення int із строкового відтворення
    /// </summary>
    class DeletingDefaultValuesInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value != 0) ? value : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value != "") ? value : 0;
        }
    }
}
