using System.Collections;
using Core;
using Gameplay.Effects;
using UnityEngine;

namespace Gameplay.Spawners
{
    public class CoinSpawner
    {
        private const float SpawnFrecuency = 1f;
        private const float SpawnDistance = 10f;
        
        private readonly IGameFactory _gameFactory;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IEffectsContainer _effectsContainer;
        private CoinView _lastCoin;
        private bool _isSpawning = false;

        public CoinSpawner(IGameFactory gameFactory, IEffectsContainer effectsContainer, ICoroutineRunner coroutineRunner)
        {
            _gameFactory = gameFactory;
            _effectsContainer = effectsContainer;
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
                    if (_effectsContainer.GetRandomEffect() is IColoredEffect coloredEffect)
                    {
                        _lastCoin.InitEffect(coloredEffect);
                    }
                }

            }
        }
    }
}