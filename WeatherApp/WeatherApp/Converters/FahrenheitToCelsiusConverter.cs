using System;
using System.Globalization;
using WeatherApp.Classes;
using Xamarin.Forms;

namespace WeatherApp.Converters
{
    public class FahrenheitToCelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double _temp = (double)value;
            double _dispalyTemp = _temp;

            switch (StaticClasses.AppContext.SelectedTempType)
            {
                case Temperature.Celsius:
                    _dispalyTemp = Math.Round((_temp - 32) * 5 / 9);
                    break;
                case Temperature.Farenheat:
                    _dispalyTemp = Math.Round(_temp);
                    break;
                default:
                    _dispalyTemp = _temp;
                    break;
            }
            return _dispalyTemp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // fr = (cel * 9) / 5 + 32;  
            throw new NotImplementedException();
        }
    }
}

