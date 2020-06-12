using System;
using System.Globalization;
using System.Windows.Data;

namespace KinderGartenWpf.Converters
{
    public class DayConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = (int)value;
            return i - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = (int)value;
            return i + 1;
        }
    }
}
