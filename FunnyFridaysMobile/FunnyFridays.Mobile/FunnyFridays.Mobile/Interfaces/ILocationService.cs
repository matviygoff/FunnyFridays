using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFridays.Mobile.Interfaces
{
    public interface ILocationService
    {
        void StartTrackingLocation();
        GeneralLocation GetLastKnownLocation();
        event EventHandler<LocationChangedEventArgs> LocationChanged;
    }
}
