using System;
using System.Threading.Tasks;
using WeatherApp.Classes;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
	public class WeatherInfoViewModel : BaseViewModel
	{
        private readonly IWeatherAPI _openWeatherAPI;

        private WeatherData _weatherInfo;

        public WeatherData WeatherInfo
        {
            get
            {
                return _weatherInfo;
            }
            set
            {
                if (_weatherInfo != value)
                {
                    _weatherInfo = value;
                    OnPropertyChanged(nameof(WeatherInfo));
                }
            }
        }
        private Temperature _currentTemperatureType;

        public Temperature CurrentTemperatureType
        {
            get { return _currentTemperatureType; }
            set
            {
                if (_currentTemperatureType != value)
                {
                    _currentTemperatureType = value;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        OnPropertyChanged(nameof(CurrentTemperatureType));
                        OnPropertyChanged(nameof(WeatherInfo));
                        });
                }
            }
        }

        public WeatherInfoViewModel(IWeatherAPI openWeatherAPI)
        {
            _openWeatherAPI = openWeatherAPI;
        }

        public async Task LoadWeatherInfo(String cityName)
        {
            WeatherInfo = await _openWeatherAPI.GetWeatherData(cityName);
        }
        //public void UpdateTemperatureType(Temperature newTemperatureType)
        //{
        //    CurrentTemperatureType = newTemperatureType;
        //}
    }
}

