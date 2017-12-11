using FunnyFridays.Mobile.Interfaces;
using FunnyFridays.Mobile.InversionOfControl;
using FunnyFridays.Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FunnyFridays.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IoC.Container.Register<ILocationServiceManager, LocationServiceManager>(Lifetime.Singleton);

            MainPage = new FunnyFridays.Mobile.MainPage();

            var locationServiceManager = IoC.Container.Resolve<ILocationServiceManager>();
            MainPage.BindingContext = new MainPageViewModel(locationServiceManager);

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private ILocationService locationService;

        public void RegisterLocationService(ILocationService locationService)
        {
            this.locationService = locationService;
        }
    }
}
