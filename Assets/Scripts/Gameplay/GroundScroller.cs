using System.Transactions;
using Core;
using Core.EventBus;
using UnityEngine;

namespace Gameplay
{
    public class GroundScroller : MonoBehaviour
    {
        private Transform _characterTransform;
        
        [SerializeField] private Transform[] groundObjects;
        
        private float _diff;
        private bool _haveTarget = false;
        
        private void Awake()
        {
            Services.Instance.GetService<IEventBusService>().OnPlayerCreated += SetTarget;
            _diff = groundObjects[1].transform.position.x - groundObjects[0].transform.position.x;
        }
        
        private void Update()
        {
            if(!_haveTarget) return;
            
            foreach (Transform ground in groundObjects)
            {
                if (ground.position.x < _characterTransform.position.x - _diff)
                {
                    var groundPosition = ground.position;
                    ground.position = new Vector3(ground.position.x + _diff * 3, 
                        groundPosition.y, groundPosition.z);
                }
            }
        }
        
        public void SetTarget(Transform target)
        {
            _characterTransform = target;
            _haveTarget = true;
        }
    }
}