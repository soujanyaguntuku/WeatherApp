using System;
using System.Collections.Generic;
using WeatherApp.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace WeatherApp.UI
{	
	public partial class SettingsPopup : Popup
	{	
		public SettingsPopup (SettingsViewModel settingsViewModel, INavigation navigation)
		{
			InitializeComponent ();

            settingsViewModel.PopupClosed += (sender, args) => ClosePopup();
            settingsViewModel.SetNavigation(navigation);
            BindingContext = settingsViewModel;
        }
        private void ClosePopup()
        {
			Dismiss(true);
        }

    }
}

