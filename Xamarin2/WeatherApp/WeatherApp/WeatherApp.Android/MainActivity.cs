using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WeatherApp.Droid
{
	[Activity (Label = "WeatherApp.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			//// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.weatherBtn);

            //button.Click += delegate {
            //	button.Text = string.Format ("{0} clicks!", count++);
            //};
            button.Click += Button_Click;


            //Weather weather =  Core.GetWeather("80005").Result;
            //FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
            //FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
            //FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
            //FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
            //FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
            //FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
            //FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.zipCodeEntry);

            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
            }
        }
    }
}


