using KinderGartenWpf.Models.Objects;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace KinderGartenWpf.Converters
{
    class PersonNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Person = (Person)value;

            if (value != null)
            {
                return $"{Person.Lastname} {Person.Firstname.First()}. {Person.Middlename.First()}.";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
