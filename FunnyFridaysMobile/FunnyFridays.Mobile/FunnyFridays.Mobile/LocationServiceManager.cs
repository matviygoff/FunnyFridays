using FunnyFridays.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFridays.Mobile
{
    public class LocationServiceManager : ILocationServiceManager
    {
        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        private ILocationService locationService;
        public void ServiceConnected(ILocationService locationService)
        {
            this.locationService = locationService;
            locationService.LocationChanged += (sender, e) => { LocationChanged(sender, e); };

            var location = GetLastKnownLocation();
            LocationChanged?.Invoke(this, new LocationChangedEventArgs(location));
        }

        private void LocationService_LocationChanged(object sender, LocationChangedEventArgs e)
        {
            LocationChanged?.Invoke(sender, e);
        }

        public GeneralLocation GetLastKnownLocation()
        {
            if (locationService == null)
            {
                throw new InvalidOperationException();
            }
            return locationService.GetLastKnownLocation();
        }
    }
}
