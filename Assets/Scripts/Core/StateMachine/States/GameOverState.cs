using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GameOverState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Services _services;
        private GameoverWindow _gameoverWindow;

        public GameOverState(StateMachine stateMachine, Services services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }
        
        
        public void Enter()
        {
            Time.timeScale = 0;
            _gameoverWindow = (GameoverWindow) _services.GetService<IWindowService>().OpenWindow(WindowId.GameoverWindow);
            _gameoverWindow.SetRetryButtonCallback(() => { _stateMachine.Enter<InitialState>(); });
            _gameoverWindow.SetQuitButtonCallback(() =>
            {
                //Cleanup
                Application.Quit();
            });
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _services.GetService<IWindowService>().CloseWindow(WindowId.GameoverWindow);
        }
    }
}