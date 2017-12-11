using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Lifetime;

namespace FunnyFridays.Mobile.InversionOfControl
{
    public static class Extensions
    {
        public static LifetimeManager ToUnityLifetimeManager(this Lifetime lifetime)
        {
            switch (lifetime)
            {
                case Lifetime.PerResolve:
                    return new PerResolveLifetimeManager();
                case Lifetime.PerThread:
                    return new PerThreadLifetimeManager();
                case Lifetime.Singleton:
                    return new ContainerControlledLifetimeManager();
                default:
                    throw new NotSupportedException($"Value {lifetime} is not supported");
            }
        }
    }
}
