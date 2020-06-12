using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KinderGartenWpf.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (bool)value ? "Мужской" : "Женский";
            return gender;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
