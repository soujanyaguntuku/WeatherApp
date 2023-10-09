using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Classes;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.StaticClasses;

namespace WeatherApp.ViewModels
{
    public class WeatherDataViewModel : BaseViewModel
    {
        private readonly IWeatherAPI _openWeatherAPI;
        private HourlyWeatherData _weatherDataFromAPI;

        private ObservableCollection<WeatherData> _weatherDataList;

        public ObservableCollection<WeatherData> WeatherDataList
        {
            get { return _weatherDataList; }
            set
            {
                if (_weatherDataList != value)
                {
                    _weatherDataList = value;
                    OnPropertyChanged(nameof(WeatherDataList));
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

                    OnPropertyChanged(nameof(CurrentTemperatureType));
                    if (_weatherDataFromAPI != null)
                    {
                        updateWeatherDataList();
                    }
                }
            }
        }

        public WeatherDataViewModel(IWeatherAPI openWeatherAPI)
        {
            _openWeatherAPI = openWeatherAPI;
            WeatherDataList = new ObservableCollection<WeatherData>();
        }

        public async Task LoadWeatherDataList(String cityName)
        {
            _weatherDataFromAPI = await _openWeatherAPI.GetThreeHourWeatherData(cityName);
            loadWeatherDatafromAPI();
        }

        private void loadWeatherDatafromAPI()
        {
            foreach (var item in _weatherDataFromAPI.HourlyWeatherDataList)
            {
                updateWeatherDataTemperature(item);
                WeatherDataList.Add(item);
            }
        }
        private void updateWeatherDataList()
        {
            foreach (var item in WeatherDataList)
            {
                updateWeatherDataTemperature(item);
            }
        }
        private void updateWeatherDataTemperature(WeatherData weatherData)
        {
            if (StaticClasses.AppContext.SelectedTempType == Temperature.Celsius)
            {
                weatherData.Main.Temperature = TemperatureConverter.ConvertToCelsius(weatherData.Main.Temperature);
            }
            else
            {
                weatherData.Main.Temperature = TemperatureConverter.ConvertToFahrenheit(weatherData.Main.Temperature);
            }
        }
    }
}