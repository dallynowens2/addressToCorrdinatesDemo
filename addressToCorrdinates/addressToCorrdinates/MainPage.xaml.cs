using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace addressToCorrdinates
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(entry.Text);

                if(result.Any())
                    resultLocation.Text = $"lat: {result.FirstOrDefault()?.Latitude}, long:{result.FirstOrDefault()?.Longitude}";

            }
            catch(FeatureNotSupportedException notSupporedex)
            {

            }
            catch(Exception ex)
            {

            }
        }

        async void Reverse_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                double lat;
                double lng;

                lat = Convert.ToDouble(entry.Text.Split(',')[0]);
                lng = Convert.ToDouble(entry.Text.Split(',')[1]);

                var result = await Geocoding.GetPlacemarksAsync(lat, lng);

                if (result.Any())
                    resultLocation.Text = result.FirstOrDefault()?.FeatureName;
            }
            catch (FeatureNotSupportedException notSupporedex)
            {

            }
            catch (Exception ex)
            {

            }

        }
    }
}
