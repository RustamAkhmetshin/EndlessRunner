using System;
using System.Collections.Generic;

namespace Core
{
    //Implementation of a DI container for registering required services.
    
    //Реализация DI контейнера для регистрации необходимых сервисов.
    
    public class Services
    {
        private static Services _instance;
        public static Services Instance => _instance ??= new Services();

        private Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public void RegisterService<TService>(TService service) where TService : IService
        {
            _services[typeof(TService)] = service;
        }

        public TService GetService<TService>() where TService : IService
        {
            if (_services.TryGetValue(typeof(TService), out var service))
            {
                if (service is TService serviceAsT)
                {
                    return serviceAsT;
                }
            }

            throw new InvalidOperationException("Service not registered.");
        }
    }
}