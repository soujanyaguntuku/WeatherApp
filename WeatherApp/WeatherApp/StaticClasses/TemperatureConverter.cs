using System;
namespace WeatherApp.StaticClasses
{
	public static class TemperatureConverter
	{
        public static double ConvertToFahrenheit(double temperatureInCelsius)
        {
            return Math.Round((temperatureInCelsius * 9 / 5) + 32);
        }

        public static double ConvertToCelsius(double temperatureInFahrenheit)
        {
            return Math.Round((temperatureInFahrenheit - 32) * 5 / 9); 
        }
    }
}

