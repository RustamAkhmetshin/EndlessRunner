using System;
using System.Collections.Generic;
using Core;
using Core.EventBus;
using UnityEngine;

namespace Gameplay
{
    public class BackgroundParalax : MonoBehaviour
    {
        [SerializeField] private Transform[] objects;

        private float _speed;
        private float _diff;
        private Transform _characterTransform;
        private Transform _lastObject;
        private bool _haveTarget = false;


        private void Awake()
        {
            Services.Instance.GetService<IEventBusService>().OnPlayerCreated += SetTarget;
            Services.Instance.GetService<IEventBusService>().OnPlayerSpeedChanged += SetSpeed;

            _lastObject = objects[^1].transform;
            _diff = objects[1].transform.position.x - objects[0].transform.position.x;
        }
        
        void Update()
        {
            if(!_haveTarget) return;
            
            foreach (Transform background in objects)
            {
                background.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));

                if (background.position.x < _characterTransform.position.x - _diff)
                {
                    var backgroundPosition = background.position;
                    background.position = new Vector3(_lastObject.position.x + _diff, 
                        backgroundPosition.y, backgroundPosition.z);

                    _lastObject = background;
                }
            }
        }
        
        public void SetTarget(Transform target)
        {
            _characterTransform = target;
            _haveTarget = true;
        }

        public void SetSpeed(float value)
        {
            _speed = value / 2;
        }
    }
}