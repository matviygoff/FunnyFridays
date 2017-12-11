using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using FunnyFridays.Mobile.Interfaces;

namespace FunnyFridays.Mobile.Droid.Services
{
    [Service]
    public class LocationService : Service, ILocationListener, ILocationService
    {
        public event EventHandler<LocationChangedEventArgs> LocationChanged;
        protected LocationManager locationManager = Android.App.Application.Context.GetSystemService("location") as LocationManager;
        protected string locationProvider;

        private IBinder binder;

        public LocationService()
        {
            binder = new LocationServiceBinder(this);
        }

        public override IBinder OnBind(Intent intent)
        {
            return binder;
        }

        public void OnLocationChanged(Location location)
        {
            LocationChanged(this, new LocationChangedEventArgs(location.ToGeneralLocation()));
        }

        public void OnProviderDisabled(string provider)
        {
//            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
//            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
//            throw new NotImplementedException();
        }

        private string GetLocationProvider()
        {
            if (locationProvider == null)
            {
                var criteria = new Criteria()
                {
                    Accuracy = Accuracy.Low
                };

                locationProvider = locationManager.GetBestProvider(criteria, true);
            }
            return locationProvider;
        }

        public void StartTrackingLocation()
        {
            locationManager.RequestLocationUpdates(GetLocationProvider(), 2000, 0, this);
        }

        public GeneralLocation GetLastKnownLocation()
        {
            var location = locationManager.GetLastKnownLocation(GetLocationProvider());
            return location.ToGeneralLocation();
        }
    }
}