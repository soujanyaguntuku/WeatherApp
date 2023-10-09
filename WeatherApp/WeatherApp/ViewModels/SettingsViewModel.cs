using System;
using System.Windows.Input;
using WeatherApp.Classes;
using WeatherApp.StaticClasses;
using WeatherApp.UI;
using Xamarin.Forms;
using AppContext = WeatherApp.StaticClasses.AppContext;

namespace WeatherApp.ViewModels
{
	public class SettingsViewModel
	{
        private INavigation _navigation;
        public ICommand ChangeLocationCommand { get; private set; }
        public ICommand CelsiusCommand { get; private set; }
        public ICommand FahrenheitCommand { get; private set; }
        public event EventHandler PopupClosed;
        public event EventHandler<TemperatureTypeChangedEventArgs> TemperatureTypeChanged;

        public SettingsViewModel()
		{
            ChangeLocationCommand = new Command(ChangeLocation);
            CelsiusCommand = new Command(ChangeToCelsius);
            FahrenheitCommand = new Command(ChangeToFahrenheit);
        }

        private void ChangeLocation()
        {
            _navigation.PushAsync(new SearchLocationPage());
            ClosePopup();
        }

        private void ChangeToCelsius()
        {
            AppContext.SelectedTempType = Temperature.Celsius;
            
            TemperatureTypeChanged?.Invoke(this, new TemperatureTypeChangedEventArgs(Temperature.Celsius));
            ClosePopup();
        }

        private void ChangeToFahrenheit()
        {
            AppContext.SelectedTempType = Temperature.Farenheat;
            TemperatureTypeChanged?.Invoke(this, new TemperatureTypeChangedEventArgs(Temperature.Farenheat));
            ClosePopup();
        }
        private void ClosePopup()
        {
            PopupClosed?.Invoke(this, EventArgs.Empty);
        }

        public void SetNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}

