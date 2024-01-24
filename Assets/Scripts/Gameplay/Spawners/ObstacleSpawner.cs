using System;
using System.Collections;
using Core;
using Gameplay.Obstacle;
using UnityEngine;

namespace Gameplay.Spawners
{
    public class ObstacleSpawner
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICoroutineRunner _coroutineRunner;
        private bool _isSpawning = false;
        private ObstacleView _lastObstacle;
        private Action _collisionCallback;
        
        private const float SpawnFrecuency = 2f;
        private const float SpawnDistance = 20f;
        
        public ObstacleSpawner(IGameFactory gameFactory, ICoroutineRunner coroutineRunner)
        {
            _gameFactory = gameFactory;
            _coroutineRunner = coroutineRunner;
        }
        
        public void StartSpawn(Action collisionCallback)
        {
            _collisionCallback = collisionCallback;
            _lastObstacle = _gameFactory.CreateObstacle();
            _lastObstacle.gameObject.SetActive(true);
            _lastObstacle.InitCallback(collisionCallback);
            _isSpawning = true;
            _coroutineRunner.StartCoroutine(SpawnCoroutine());
        }

        public void StopSpawn()
        {
            _isSpawning = false;
        }
        
        private IEnumerator SpawnCoroutine()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(SpawnFrecuency);
                if(!_isSpawning) yield break;
                
                Vector3 prevPosition = _lastObstacle.transform.position;
                _lastObstacle = _gameFactory.CreateObstacle();
                _lastObstacle.gameObject.SetActive(true);
                _lastObstacle.transform.position = prevPosition + Vector3.right * SpawnDistance;
                _lastObstacle.InitCallback(_collisionCallback);
            }
        }
    }
}