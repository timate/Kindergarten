using System;
using System.Globalization;
using System.Windows.Data;

namespace KinderGartenWpf.Converters
{
    public class DateToColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((DateTime)value).DayOfWeek;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}
