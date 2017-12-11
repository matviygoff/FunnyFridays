using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFridays.Mobile
{
    public class  LocationChangedEventArgs: EventArgs
    {
        private GeneralLocation location;
        public LocationChangedEventArgs(GeneralLocation location)
        {
            this.location = location;
        }

        public GeneralLocation Location => location;

    }
}
