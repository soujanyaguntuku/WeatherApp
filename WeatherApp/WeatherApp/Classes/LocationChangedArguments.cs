using System;
namespace WeatherApp.Classes
{
	public class LocationChangedArguments : EventArgs
	{
		public string Location { get; }
		public LocationChangedArguments(string location)
		{
			Location = location;
		 }
	}
}

