using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Obstacle
{
    public class ObstacleRotator : MonoBehaviour
    {
        public float rotationSpeed = 150f; 

        private void Update()
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}