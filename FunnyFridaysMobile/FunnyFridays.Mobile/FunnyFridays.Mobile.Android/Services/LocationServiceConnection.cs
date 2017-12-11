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
    public class LocationServiceConnection : Java.Lang.Object, IServiceConnection
    {
        private LocationServiceBinder binder;
        public LocationServiceBinder Binder => binder;
        public event EventHandler ServiceConnected;

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            binder = service as LocationServiceBinder;
            ServiceConnected(this, null);
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            binder = null;            
        }
    }
}