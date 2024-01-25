using System;
using Core;
using Core.EventBus;
using UnityEngine;

namespace Gameplay
{
    //Camera component for following the character.
    
    //Компонент камеры для следования за персонажем.
    
    public class CameraFollow : MonoBehaviour
    {
        public Transform followTarget;

        private Vector3 _offset;
        private bool _haveTarget = false;
        
        private void Awake()
        {
            Services.Instance.GetService<IEventBusService>().OnPlayerCreated += SetTarget;
        }
        
        private void LateUpdate()
        {
            if(!_haveTarget) return;
            
            Vector3 newPosition = followTarget.position - _offset;
            Vector3 current = transform.position;
            transform.position = new Vector3(newPosition.x, current.y, current.z);
        }

        public void SetTarget(Transform target)
        {
            followTarget = target;
            _offset = followTarget.position - transform.position;
            _haveTarget = true;
        }

        private void OnDestroy()
        {
            Services.Instance.GetService<IEventBusService>().OnPlayerCreated -= SetTarget;
        }
    }
}