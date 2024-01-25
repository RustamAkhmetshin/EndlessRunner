
using Gameplay;
using Gameplay.Character;
using Gameplay.Obstacle;
using UnityEngine;

namespace Core
{
    public interface IGameFactory : IService
    {
        CharacterView CreateCharacter();
        GameObject CreateBackground();
        GameObject CreateGround();
        CoinView CreateCoin();
        void DisableCoin(CoinView coin);
        ObstacleView CreateObstacle();
        void DisableObstacle(ObstacleView coin);
    }
}