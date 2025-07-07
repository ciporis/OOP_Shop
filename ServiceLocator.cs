using System;
using System.Collections.Generic;

namespace Shop_5_5
{
    internal static class ServiceLocator
    {
        public static Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            Services[typeof(T)] = service;
        }

        public static T GetService<T>()
        {
            return (T)Services[typeof(T)];
        }
    }
}
