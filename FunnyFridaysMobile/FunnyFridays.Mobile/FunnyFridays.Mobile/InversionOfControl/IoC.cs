using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFridays.Mobile.InversionOfControl
{
    public static class IoC
    {
        public static DependencyContainer Container { get; private set; }

        static IoC()
        {
            Container = new DependencyContainer();
        }
    }
}
