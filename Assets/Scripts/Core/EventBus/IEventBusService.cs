using System;
using System.Transactions;
using UnityEngine;

namespace Core.EventBus
{
    public interface IEventBusService : IService
    {
        event Action<Transform> OnPlayerCreated;
        event Action<float> OnPlayerSpeedChanged;
        void CreatePlayer(Transform playerTransform);
        void ChangePlayerSpeed(float newSpeed);
    }
}