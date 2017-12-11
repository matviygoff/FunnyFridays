using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Android.Content;
using FunnyFridays.Mobile.Droid.Services;
using FunnyFridays.Mobile.Interfaces;
using FunnyFridays.Mobile.InversionOfControl;

namespace FunnyFridays.Mobile.Droid
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        private void InitLocationService()
        {
            var locationServiceConnection = new LocationServiceConnection();

            locationServiceConnection.ServiceConnected += (sender, e) =>
            {
                var locationSerivceConnection = sender as LocationServiceConnection;
                locationSerivceConnection.Binder.Service.StartTrackingLocation();

                var locationServiceManager = IoC.Container.Resolve<ILocationServiceManager>();
                locationServiceManager.ServiceConnected(locationSerivceConnection.Binder.Service);
            };

            var intent = new Intent(Android.App.Application.Context, typeof(LocationService));
            BindService(intent, locationServiceConnection, Bind.AutoCreate);
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!

            InitLocationService();
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}