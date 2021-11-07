using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Entidades;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Solaris
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PageCitas : Page
    {
        public PageCitas()
        {
            this.InitializeComponent();

            
        }
        private async void GeMyLocation_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var geolocator = new Geolocator();
            var position = await geolocator.GetGeopositionAsync();

            var mapLocation = await MapLocationFinder.FindLocationsAtAsync(position.Coordinate.Point);
     
        }

        private async void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            if (MyMap.Is3DSupported)
            {
                MyMap.Style = MapStyle.Aerial3DWithRoads;
                //MyMap.Style = MapStyle.Terrain;
                MyMap.MapServiceToken = "xMVOXHTbPpVibifKTfYL~0mjYySjDBN_zxBqqOrHmhQ~ArZHhKG-7c-VzhaZFbmQ_Wj8LVPx8XMnFH4c9kDxgbOwA6Yp-Xl3bMqcPyGyCtDh";

                BasicGeoposition geoPosition = new BasicGeoposition();
                geoPosition.Latitude = 37.3826;
                geoPosition.Longitude = -5.99629;
                // get position
                Geopoint myPoint = new Geopoint(geoPosition);
                //create POI
                MapIcon myPOI = new MapIcon { Location = myPoint, Title = "My Position", NormalizedAnchorPoint = new Point(0.5, 1.0), ZIndex = 0 };
                // Display an image of a MapIcon
                myPOI.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
                // add to map and center it
                MyMap.MapElements.Add(myPOI);
                MyMap.Center = myPoint;
                MyMap.ZoomLevel = 10;
    

                MapScene mapScene = MapScene.CreateFromLocationAndRadius(new Geopoint(geoPosition), 500, 150, 70);
                await MyMap.TrySetSceneAsync(mapScene);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (String)e.Parameter;

            txtTittleMainPage.Text = "Bienvenido de nuevo, " + parameters;

        }


    }
}
