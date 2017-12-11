using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFridays.Mobile.Interfaces
{
    public interface ILocationServiceManager
    {
        void ServiceConnected(ILocationService locationService);
        event EventHandler<LocationChangedEventArgs> LocationChanged;
        GeneralLocation GetLastKnownLocation();
    }
}
