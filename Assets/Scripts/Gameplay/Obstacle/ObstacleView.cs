using System;
using Core;
using Gameplay.Character;
using UnityEngine;

namespace Gameplay.Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        public float movingSpeed = 5f;

        private Action _collisionCallback;
        private Transform _cameraTransform;
        
        private void Start()
        {
            if (Camera.main != null) _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            transform.Translate(movingSpeed * Time.deltaTime * Vector3.left);
            
            if (transform.position.x < _cameraTransform.position.x - Screen.width / 200f)
            {
                Services.Instance.GetService<IGameFactory>().DisableObstacle(this);
            }
        }

        public void InitCallback(Action callback)
        {
            _collisionCallback = callback;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            CharacterView characterView = other.GetComponent<CharacterView>();
            if(characterView == null) return;

            _collisionCallback();
        }
    }
}