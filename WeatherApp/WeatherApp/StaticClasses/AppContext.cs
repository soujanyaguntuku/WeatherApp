using System;
using WeatherApp.Classes;

namespace WeatherApp.StaticClasses
{
	public static class AppContext
	{
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/";
        public static string OpenWeatherMapAPIKey = "89ae1ef3c84852830e4915369a3242f9";
        public static Temperature SelectedTempType = Temperature.Celsius;
        
    }
}

