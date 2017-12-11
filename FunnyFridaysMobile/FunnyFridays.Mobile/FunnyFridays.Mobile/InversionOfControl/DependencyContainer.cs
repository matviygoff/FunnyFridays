using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace FunnyFridays.Mobile.InversionOfControl
{
    public class DependencyContainer
    {
        private readonly IUnityContainer unityContainer = new UnityContainer();

        public DependencyContainer Clear()
        {
            foreach (var registration in unityContainer.Registrations.Where(r => r.LifetimeManager != null))
            {
                registration.LifetimeManager.RemoveValue();
            }

            return this;
        }

        #region Register<T>

        public DependencyContainer Register<T>()
        {
            return Register<T, T>();
        }

        public DependencyContainer Register<T>(Lifetime lifetime)
        {
            return Register<T, T>(lifetime);
        }

        public DependencyContainer Register<T>(params object[] ctorParameterValues)
        {
            return Register<T, T>(ctorParameterValues);
        }

        public DependencyContainer Register<T>(Lifetime lifetime, params object[] ctorParameterValues)
        {
            return Register<T, T>(lifetime, ctorParameterValues);
        }

        public DependencyContainer Register<T>(string name, params object[] ctorParameterValues)
        {
            return Register<T, T>(name, ctorParameterValues);
        }

        public DependencyContainer Register<T>(string name, Lifetime lifetime, params object[] ctorParameterValues)
        {
            return Register<T, T>(name, lifetime, ctorParameterValues);
        }

        #endregion // Register<T>

        #region Register <TFrom, TTo>

        public DependencyContainer Register<TFrom, TTo>()
                where TTo : TFrom
        {
            unityContainer.RegisterType<TFrom, TTo>();

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(Lifetime lifetime)
            where TTo : TFrom
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();

            unityContainer.RegisterType<TFrom, TTo>(lifetimeManager);

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(params object[] parameterValues)
            where TTo : TFrom
        {
            var constructor = new InjectionConstructor(parameterValues);
            unityContainer.RegisterType<TFrom, TTo>(constructor);

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(Lifetime lifetime, params object[] parameterValues)
            where TTo : TFrom
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();
            var constructor = new InjectionConstructor(parameterValues);

            unityContainer.RegisterType<TFrom, TTo>(lifetimeManager, constructor);

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(string name, params object[] parameterValues)
            where TTo : TFrom
        {
            var constructor = new InjectionConstructor(parameterValues);

            unityContainer.RegisterType<TFrom, TTo>(name, constructor);

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(string name, Lifetime lifetime, params object[] parameterValues)
            where TTo : TFrom
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();
            var constructor = new InjectionConstructor(parameterValues);

            unityContainer.RegisterType<TFrom, TTo>(name, lifetimeManager, constructor);

            return this;
        }

        public DependencyContainer Register<TFrom, TTo>(string name, Lifetime lifetime)
            where TTo : TFrom
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();
            unityContainer.RegisterType<TFrom, TTo>(name, lifetimeManager);

            return this;
        }

        public DependencyContainer RegisterWithInjectionMethod<TFrom, TTo>(Lifetime lifetime, string injectionMethod, params object[] parameters)
            where TTo : TFrom
        {
            unityContainer.RegisterType<TFrom, TTo>(lifetime.ToUnityLifetimeManager(), new InjectionMethod(injectionMethod, parameters));
            return this;
        }

        #endregion // Register <TFrom, TTo>

        #region RegisterInstance<T>

        public DependencyContainer RegisterInstance<T>(T instance)
        {
            unityContainer.RegisterInstance<T>(instance);

            return this;
        }

        public DependencyContainer RegisterInstance<T>(T instance, Lifetime lifetime)
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();

            unityContainer.RegisterInstance<T>(instance, lifetimeManager);

            return this;
        }

        public DependencyContainer RegisterInstance<T>(string name, T instance)
        {
            unityContainer.RegisterInstance<T>(name, instance);

            return this;
        }

        public DependencyContainer RegisterInstance<T>(string name, T instance, Lifetime lifetime)
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();

            unityContainer.RegisterInstance<T>(name, instance, lifetimeManager);

            return this;
        }

        public DependencyContainer RegisterInstanceFactoryMethodFor<T>(T instance, Lifetime lifetime)
        {
            LifetimeManager lifetimeManager = lifetime.ToUnityLifetimeManager();

            unityContainer.RegisterType<T>(lifetimeManager, new InjectionFactory(c => instance));

            return this;
        }

        #endregion // RegisterInstance<T>

        #region Resolve<T>

        public T Resolve<T>()
        {
//            var parameters = ctorParameters.Select(p => new ParameterOverride(p.Name, p.Value)).ToArray();

            return unityContainer.Resolve<T>(/*parameters*/);
        }

        public T Resolve<T>(string name/*, params NameValueParameter[] ctorParameters*/)
        {
//            var parameters = ctorParameters.Select(p => new ParameterOverride(p.Name, p.Value)).ToArray();

            return unityContainer.Resolve<T>(name/*, parameters*/);
        }

        #endregion // Resolve<T>

    }
}
