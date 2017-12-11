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

namespace FunnyFridays.Mobile.Droid.Services
{
    public class LocationServiceBinder:Binder
    {
        private LocationService locationService;
        public LocationService Service => locationService;
        public LocationServiceBinder(LocationService locationService)
        {
            this.locationService = locationService;
        }
    }
}