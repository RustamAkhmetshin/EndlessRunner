using System;
using UnityEngine;

namespace Core.EventBus
{
    //Service for communication between components via events.
    
    //Сервис для общения между компонентами посредством ивентов.
    
    public class EventBusService : IEventBusService
    {
        public EventBusService() { }

        public event Action<Transform> OnPlayerCreated;
        public event Action<float> OnPlayerSpeedChanged;
        
        public void CreatePlayer(Transform playerTransform)
        {
            OnPlayerCreated?.Invoke(playerTransform);
        }
        
        public void ChangePlayerSpeed(float newSpeed)
        {
            OnPlayerSpeedChanged?.Invoke(newSpeed);
        }
    }
}