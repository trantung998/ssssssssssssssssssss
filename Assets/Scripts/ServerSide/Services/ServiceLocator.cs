using System;
using System.Collections.Generic;

namespace ServerSide.Services
{
    public sealed class ServicesLocator
    {
        private static readonly IDictionary<Type, object> _serviceCache;
        private static readonly ServicesLocator _instance = new ServicesLocator();

        public static ServicesLocator Instance
        {
            get { return _instance; }
        }

        static ServicesLocator()
        {
            _serviceCache = new Dictionary<Type, object>();
        }

        private ServicesLocator()
        {
        }

        public T GetService<T>()
        {
            var key = typeof(T);
            if (!_serviceCache.ContainsKey(key))
            {
                // _serviceCache.Add(key, (T) Activator.CreateInstance(key));
                throw new ArgumentException(string.Format("Type '{0}' has not been registered.", key.Name));
            }

            return (T) _serviceCache[key];
        }

        public void Register<T>(T service)
        {
            var key = typeof(T);
            if (!_serviceCache.ContainsKey(key))
            {
                _serviceCache.Add(key, service);
            }
            else // overwrite the existing instance.
            {
                _serviceCache[key] = service;
            }
        }

        public T CreateNewInstanceOfService<T>()
        {
            var key = typeof(T);
            if (!_serviceCache.ContainsKey(key))
            {
                throw new ArgumentException(string.Format("Type '{0}' has not been registered.", key.Name));
            }

            var objectType = _serviceCache[key].GetType();
            return (T) Activator.CreateInstance(objectType);
        }
    }
}