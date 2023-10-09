using System;
namespace WeatherApp.Classes
{
	public class TemperatureTypeChangedEventArgs : EventArgs
    {
        public Temperature NewTemperatureType { get; }	
        public TemperatureTypeChangedEventArgs(Temperature newTemperatureType) 
		{
			NewTemperatureType = newTemperatureType;
		}
	}
}

