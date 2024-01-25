using Configs;
using Gameplay;
using Gameplay.Character;
using Gameplay.Obstacle;
using UnityEngine;

namespace Core
{
    //The main factory for all gameplay objects.
    
    //Основная фабрика всех геймплейных объектов
    
    public class GameFactory : IGameFactory
    {
        private ObjectPool<CoinView> _coinsPool;
        private ObjectPool<ObstacleView> _obstaclePool;
        public GameFactory()
        {
            _coinsPool = new ObjectPool<CoinView>(Resources.Load<CoinView>(Constants.CoinPrefabPath), 10);    
            _obstaclePool = new ObjectPool<ObstacleView>(Resources.Load<ObstacleView>(Constants.ObstaclePrefabPath), 5);    
        }
        
        public CharacterView  CreateCharacter()
        {
            CharacterView prefab = Resources.Load<CharacterView>(Constants.CharacterPrefabPath);
            if (prefab == null) return null;
            
            CharacterView instance = Object.Instantiate(prefab);
            return instance;
        }

        public GameObject CreateBackground()
        {
            GameObject prefab = Resources.Load<GameObject>(Constants.BackgroundPrefabPath);
            return Instantiate(prefab);
        }

        public GameObject CreateGround()
        {
            GameObject prefab = Resources.Load<GameObject>(Constants.GroundPrefabPath);
            return Instantiate(prefab);
        }

        public CoinView CreateCoin()
        {
            return _coinsPool.GetPooledObject();
        }

        public void DisableCoin(CoinView coin)
        {
            _coinsPool.ReturnObjectToPool(coin);
        }
        
        public ObstacleView CreateObstacle()
        {
            return _obstaclePool.GetPooledObject();
        }

        public void DisableObstacle(ObstacleView coin)
        {
            _obstaclePool.ReturnObjectToPool(coin);
        }

        private GameObject Instantiate(GameObject prefab)
        {
            if (prefab == null) return null;
            
            GameObject instance = Object.Instantiate(prefab);
            return instance;
        }
    }
}