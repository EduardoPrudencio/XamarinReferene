using System;
using System.Globalization;
using Xamarin.Forms;

namespace Octus.Converters
{
    public class BolleanToRedOrWhite : IValueConverter
    {
        string corPositiva = "#a1edb5";
        string corNegativa = "#f7665c";

        public BolleanToRedOrWhite()
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
