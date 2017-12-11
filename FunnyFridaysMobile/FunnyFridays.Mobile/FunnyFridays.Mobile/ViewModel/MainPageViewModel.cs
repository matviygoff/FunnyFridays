using FunnyFridays.Mobile.Interfaces;
using FunnyFridays.Mobile.InversionOfControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunnyFridays.Mobile.ViewModel
{
    public class MainPageViewModel : BindableObject
    {

        private GeneralLocation generalLocation;
        public GeneralLocation GeneralLocation
        {
            get
            {
                return generalLocation;
            }
            set
            {
                if (value != generalLocation)
                {
                    generalLocation = value;
                    OnPropertyChanged(nameof(GeneralLocation));
                }
            }
        }

        private ICommand getCoordsCommand;
        public ICommand GetCoordsCommand
        {
            get
            {
                if (getCoordsCommand == null)
                {
                    getCoordsCommand = new Command(() => GeneralLocation = locationServiceManager.GetLastKnownLocation());
                }
                return getCoordsCommand;
            }
        }

        private ILocationServiceManager locationServiceManager;
        public MainPageViewModel(ILocationServiceManager locationServiceManager)
        {
            this.locationServiceManager = locationServiceManager;
            locationServiceManager.LocationChanged += LocationServiceManager_LocationChanged;
        }

        private void LocationServiceManager_LocationChanged(object sender, LocationChangedEventArgs e)
        {
            GeneralLocation = e.Location;
        }
    }
}
