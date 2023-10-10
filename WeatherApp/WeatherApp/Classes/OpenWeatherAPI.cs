using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.StaticClasses;
using AppContext = WeatherApp.StaticClasses.AppContext;

namespace WeatherApp.Classes
{
    public class OpenWeatherAPI : IWeatherAPI
	{
        HttpClient _client;

        public OpenWeatherAPI()
		{
			_client = new HttpClient();
		}

        public async Task<WeatherData> GetWeatherData(String city)
		{
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(GenerateRequestUri("weather", city));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                //TODO add proper exception handling
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return weatherData;
        }

        public async Task<HourlyWeatherData> GetThreeHourWeatherData(String city)
        {
            HourlyWeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(GenerateRequestUri("forecast", city));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                   weatherData = JsonConvert.DeserializeObject<HourlyWeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return weatherData;
        }
       

    private string GenerateRequestUri(string endPoint,string queryString)
        {
            // https://api.openweathermap.org/data/2.5/weather?q={city name}&units=imperial&appid={API key}

            string requestUri = AppContext.OpenWeatherMapEndpoint;
            requestUri += endPoint;
            requestUri += $"?q={queryString}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={AppContext.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
    public class BaseClass
    {
        public void Display()
        {
            Console.WriteLine("BaseClass Display Method");
        }
    }

    public class DerivedClass : BaseClass
    {
        public new void Display()
        {
            Console.WriteLine("DerivedClass Display Method");
        }
    }
}

