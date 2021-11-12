using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace mapssss
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();


            Pin pin = new Pin
            {
                Label = "Lokalozacja x,y",
                Address = "Wilgotność wynosi Z",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("sensor1.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "sensor1.png", WidthRequest = 20, HeightRequest = 20 }),
                Position = new Position(52.254843, 20.898503)
            };
            map.Pins.Add(pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(500)));

            ApplyMapTheme();
        }

        private void ApplyMapTheme()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"mapssss.MapResources.MapTheme.json");
            string themeFile;
            using (var reader = new System.IO.StreamReader(stream))
            {
                themeFile = reader.ReadToEnd();
                map.MapStyle=MapStyle.FromJson(themeFile);
            }
        }
    }
}
