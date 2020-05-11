using System;
using System.Globalization;
using Xamarin.Forms;

namespace Octus.Converters
{
    public class BolleanToTwoPossibleColors : IValueConverter
    {
        string corPositiva = "#FFFFFF";
        string corNegativa = "#757575";

        public BolleanToTwoPossibleColors()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((bool)value) ? corNegativa : corPositiva;
                

            return corPositiva;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
