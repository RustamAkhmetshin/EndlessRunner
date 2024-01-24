using Gameplay.Spawners;
using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GameplayState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Services _services;
        private CoinSpawner _coinSpawner;
        private ObstacleSpawner _obstacleSpawner;
        
        public GameplayState(StateMachine stateMachine, ICoroutineRunner coroutineRunner, Services services)
        {
            _stateMachine = stateMachine;
            _services = services;
            
            _coinSpawner = new CoinSpawner(services.GetService<IGameFactory>(), coroutineRunner);
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
            _stateMachine.Enter<GameOverState>();
        }
        
        private void LoadUI()
        {
            GameplayUI gameplayUI = (GameplayUI) _services.GetService<IWindowService>().OpenWindow(WindowId.GameplayUI);
            gameplayUI.SetButtonCallback(() =>
            {
                _stateMachine.Enter<GamePauseState>();
            });
        }

        public void Exit()
        {
            _coinSpawner.StopSpawn();
            _obstacleSpawner.StopSpawn();
        }
    }
}