using Gameplay.Effects;
using Gameplay.Spawners;
using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Services _services;
        private CoinSpawner _coinSpawner;
        private ObstacleSpawner _obstacleSpawner;
        
        public GameplayState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, Services services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
            
            IEffectsContainer effectsContainer = new EffectsContainer();
            effectsContainer.AddEffect("SpeedUpEffect", new SpeedUpEffect());
            effectsContainer.AddEffect("SlowDownEffect", new SlowDownEffect());
            effectsContainer.AddEffect("FlyEffect", new FlyEffect(coroutineRunner));

            
            _coinSpawner = new CoinSpawner(services.GetService<IGameFactory>(), effectsContainer, coroutineRunner);
            _obstacleSpawner = new ObstacleSpawner(services.GetService<IGameFactory>(), coroutineRunner);
        }
        
        public void Enter()
        {
            LoadUI();
            _coinSpawner.StartSpawn();
            _obstacleSpawner.StartSpawn(EnterGameOverState);
        }

        private void EnterGameOverState()
        {
            _gameStateMachine.Enter<GameOverState>();
        }
        
        private void LoadUI()
        {
            Window window = _services.GetService<IWindowService>().OpenWindow(WindowId.GameplayUI);

            if (window is GameplayUI gameplayUI)
            {
                gameplayUI.SetButtonCallback(() =>
                {
                    _gameStateMachine.Enter<GamePauseState>();
                });
            }
        }

        public void Exit()
        {
            _coinSpawner.StopSpawn();
            _obstacleSpawner.StopSpawn();
        }
    }
}