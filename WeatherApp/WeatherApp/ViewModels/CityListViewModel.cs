using System;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherApp.Classes;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
	public class CityListViewModel : BaseViewModel
	{
        public event EventHandler<LocationChangedArguments> TemperatureTypeChanged;
        public Command CitySelectedTagChangedCommand
        {
            get
            {
                return new Command((sender) =>
                {
                    string cityName = sender as string;
                    TemperatureTypeChanged?.Invoke(this, new LocationChangedArguments(cityName));
                });
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    FilterCities();
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        private ObservableCollection<string> _allCities;
        public ObservableCollection<string> AllCities
        {
            get { return _allCities; }
            set
            {
                _allCities = value;
                OnPropertyChanged(nameof(AllCities));
            }
        }
        private ObservableCollection<string> _filteredCities;
        public ObservableCollection<string> FilteredCities
        {
            get { return _filteredCities; }
            set
            {
                _filteredCities = value;
                OnPropertyChanged(nameof(FilteredCities));
            }
        }

        public CityListViewModel()
		{
            AllCities = new ObservableCollection<string>
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Oslo",
            "London",
            "Chennai",
            "Srikakulam"
        };

            // Initialize the filtered list with all cities
            FilteredCities = AllCities;
        }

       
        private void FilterCities()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredCities = AllCities;
            }
            else
            {
                FilteredCities = new ObservableCollection<string>(
                    AllCities.Where(city => city.ToLower().Contains(SearchText.ToLower()))
                );
            }
        }
    }
}

