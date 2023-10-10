
using WeatherApp.Classes;
using WeatherApp.Interfaces;
using WeatherApp.UI;
using WeatherApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IWeatherAPI _openWeatherAPI;
        private readonly WeatherInfoViewModel _weatherInfoViewModel;
        private readonly WeatherDataViewModel _weatherDataViewModel;
        private readonly SettingsViewModel _settingsViewModel;
        public MainPage()
        {
            InitializeComponent();
            _openWeatherAPI = new OpenWeatherAPI();
            _settingsViewModel = new SettingsViewModel();

            _weatherInfoViewModel = new WeatherInfoViewModel(_openWeatherAPI);
            _weatherDataViewModel = new WeatherDataViewModel(_openWeatherAPI);
            var mainViewModel = new MainViewModel(_weatherInfoViewModel,
                                                    _weatherDataViewModel,
                                                    _settingsViewModel,
                                                    "Oslo");
            mainViewModel.SetNavigation(this.Navigation);
            BindingContext = mainViewModel;
        }

        async void OnMapImage_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SearchLocationPage());
        }
       
    }

}

