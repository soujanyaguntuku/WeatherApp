﻿using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
	public class Wind
	{
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}

