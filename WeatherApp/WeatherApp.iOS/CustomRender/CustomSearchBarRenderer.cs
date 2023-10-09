using System;
using UIKit;
using WeatherApp.iOS.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace WeatherApp.iOS.CustomRender
{
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove the border by setting the background to transparent
                Control.BarStyle = new UIBarStyle();
            }
        }
    }
}

