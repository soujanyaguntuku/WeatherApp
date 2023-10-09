using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
	public class HourlyWeatherData
	{
        [JsonProperty("list")]
        public List<WeatherData> HourlyWeatherDataList { get; set; }
        [JsonProperty("cnt")]
        public int Count { get; set; }
    }
}

