using System;
using Newtonsoft.Json;
using WeatherApp.ViewModels;

namespace WeatherApp.Models
{
	public class Main : BaseViewModel
	{
        
        private double _temperature;
        [JsonProperty("temp")]
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                }
            }
        }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
    }
}

