﻿using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
	public class Coord
	{
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}

