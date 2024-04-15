using System.Globalization;
using System.Windows.Data;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Перетворення одного елемта із списка enum
    /// </summary>
    internal class TransformationToEnumTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            targetType = value.GetType();
            
            return EnumHelper.Description((Enum)Enum.ToObject(targetType, value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        
    }
}
