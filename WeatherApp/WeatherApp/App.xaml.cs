using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
          
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
            var ci = new CultureInfo("fr"); // Set the desired culture (e.g., French)
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

