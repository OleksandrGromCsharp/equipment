using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

using equipment.Entities;

namespace equipment.Infrastructure.Converter
{
    /// <summary>
    /// Перетворення списків Enum
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
    public class EnumToCollectionConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return EnumHelper.GetAllValuesAndDescriptions(value.GetType()).OrderBy(e => e.Description);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
