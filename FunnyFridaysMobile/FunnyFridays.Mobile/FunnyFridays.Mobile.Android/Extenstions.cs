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

namespace FunnyFridays.Mobile.Droid
{
    public static class Extenstions
    {
        public static GeneralLocation ToGeneralLocation(this Location location)
        {
            var generalLocation = new GeneralLocation()
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };
            return generalLocation;
        }
    }
}