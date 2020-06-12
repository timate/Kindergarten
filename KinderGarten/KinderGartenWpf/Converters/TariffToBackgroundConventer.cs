using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace KinderGartenWpf.Converters
{
    public class TariffToBackgroundConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var DefaultBG = new SolidColorBrush { Color = new Color { R = 0, G = 0, B = 0, A = 10 } };

            if (value is null)
                return DefaultBG;
            return new SolidColorBrush { Color = Colors.LightGoldenrodYellow };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
