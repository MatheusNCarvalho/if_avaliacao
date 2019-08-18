using System;
using System.Globalization;
using Xamarin.Forms;

namespace IFAvaliacao.Converter
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
                return value.ToString();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value as string, out var valueDouble))
                return valueDouble;
            return value;
        }
    }
}