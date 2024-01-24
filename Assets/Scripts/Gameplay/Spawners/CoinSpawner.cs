using System.Collections;
using Core;
using Gameplay.Effects;
using UnityEngine;

namespace Gameplay.Spawners
{
    public class CoinSpawner
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICoroutineRunner _coroutineRunner;
        private CoinView _lastCoin;
        private bool _isSpawning = false;
        
        private const float SpawnFrecuency = 1f;
        private const float SpawnDistance = 10f;
        
        public CoinSpawner(IGameFactory gameFactory, ICoroutineRunner coroutineRunner)
        {
            _gameFactory = gameFactory;
            _coroutineRunner = coroutineRunner;
        }

        public void StartSpawn()
        {
            _lastCoin = _gameFactory.CreateCoin();
            _lastCoin.gameObject.SetActive(true);
            _isSpawning = true;
            _coroutineRunner.StartCoroutine(SpawnCoroutine());
        }

        public void StopSpawn()
        {
            _isSpawning = false;
        }

        //Параметры нужно вынести в конфиги
        private IEnumerator SpawnCoroutine()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(SpawnFrecuency);
                if(!_isSpawning) yield break;
                
                Vector3 prevPosition = _lastCoin.transform.position;
                _lastCoin = _gameFactory.CreateCoin();
                _lastCoin.gameObject.SetActive(true);
                _lastCoin.transform.position = prevPosition + Vector3.right * SpawnDistance;
                
                if (Random.Range(0f, 1f) <= 0.3f) 
                {
                    int randomIndex = Random.Range(0, 3);

                    switch (randomIndex)
                    {
                        case 0:
                            _lastCoin.InitEffect(new SpeedUpEffect());
                            break;
                        
                        case 1:
                            _lastCoin.InitEffect(new SlowDownEffect());
                            break;
                        
                        case 2:
                            _lastCoin.InitEffect(new FlyEffect(_coroutineRunner));
                            break;
                    }
                }

            }
        }
    }
}