using System;
using System.Globalization;
using WeatherApp.Classes;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
	public class TemperatureTypeConevrter : IValueConverter
    {
		
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Temperature temperature)
            {
                return temperature == Temperature.Celsius ? "C" : "F";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

