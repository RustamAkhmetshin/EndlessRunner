using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GameOverState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Services _services;
        
        public GameOverState(GameStateMachine gameStateMachine, Services services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
        }
        
        
        public void Enter()
        {
            Time.timeScale = 0;
            Window window = _services.GetService<IWindowService>().OpenWindow(WindowId.GameoverWindow);
            
            if (window is GameoverWindow gameoverWindow)
            {
                gameoverWindow.SetRetryButtonCallback(() => { _gameStateMachine.Enter<InitialState>(); });
                gameoverWindow.SetQuitButtonCallback(() =>
                {
                    //Cleanup
                    Application.Quit();
                });
            }
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _services.GetService<IWindowService>().CloseWindow(WindowId.GameoverWindow);
        }
    }
}