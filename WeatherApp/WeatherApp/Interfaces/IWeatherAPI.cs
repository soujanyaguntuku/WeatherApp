using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
	public interface IWeatherAPI
	{
        Task<WeatherData> GetWeatherData(string city);
        Task<HourlyWeatherData> GetThreeHourWeatherData(String city);
    }
}

