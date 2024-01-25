using System;
using Gameplay.Character;
using UnityEngine;

namespace Gameplay.Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        public float movingSpeed = 5f;

        private Action _collisionCallback;

        private void Update()
        {
            transform.Translate(movingSpeed * Time.deltaTime * Vector3.left);
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