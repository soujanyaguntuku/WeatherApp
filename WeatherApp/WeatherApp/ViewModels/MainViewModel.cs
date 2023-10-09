using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using WeatherApp.Classes;
using WeatherApp.UI;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly WeatherInfoViewModel _weatherInfoViewModel;
        private readonly WeatherDataViewModel _weatherDataViewModel;
        private readonly SettingsViewModel _settingsViewModel;
        private readonly Timer _updateTimer;

        private INavigation _navigation;

        public ICommand OnListImage_Tapped { get; private set; }


        private bool _isNetworkConnected;
        public bool IsNetworkConnected
        {
            get
            {
                return _isNetworkConnected;
            }
            set
            {
                if(_isNetworkConnected != value)
                {
                    _isNetworkConnected = value;
                    OnPropertyChanged(nameof(IsNetworkConnected));
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
                        _weatherInfoViewModel.CurrentTemperatureType = value;
                        _weatherDataViewModel.CurrentTemperatureType = value;
                  
                }
            }
        }
       
        
        public MainViewModel(WeatherInfoViewModel weatherInfoViewModel,
                            WeatherDataViewModel weatherDataViewModel,
                            SettingsViewModel settingsViewModel)
        {
            
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            
            _settingsViewModel = settingsViewModel;
            _weatherInfoViewModel = weatherInfoViewModel;
            _weatherDataViewModel = weatherDataViewModel;

            OnListImage_Tapped = new Command(OnListImageTapped);

            _settingsViewModel.TemperatureTypeChanged += _settingsViewModel_TemperatureTypeChanged;

            // Set up the timer to call LoadWeatherData at regular intervals (e.g., every 60 seconds)
            _updateTimer = new Timer(10000); // Update data every 60 seconds (adjust as needed)
            _updateTimer.Elapsed += OnTimerElapsed;
            _updateTimer.Start();

            LoadWeatherData();
            
        }

        private void OnListImageTapped(object obj)
        {
            _navigation.ShowPopup(new SettingsPopup(_settingsViewModel, _navigation));
        }

        private void _settingsViewModel_TemperatureTypeChanged(object sender, Classes.TemperatureTypeChangedEventArgs e)
        {
            CurrentTemperatureType = e.NewTemperatureType;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                IsNetworkConnected = true;
            }
            else
            {
                IsNetworkConnected = false;
            }
        }

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await LoadWeatherData();
        }

        public WeatherInfoViewModel WeatherInfoViewModel => _weatherInfoViewModel;
        public WeatherDataViewModel WeatherDataViewModel => _weatherDataViewModel;

        private async Task LoadWeatherData()
        {
            string _cityName = "Oslo";
            var infoTask = _weatherInfoViewModel.LoadWeatherInfo(_cityName);
            var dataTask = _weatherDataViewModel.LoadWeatherDataList(_cityName);

            await Task.WhenAll(infoTask, dataTask);
        }

        public void SetNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}

