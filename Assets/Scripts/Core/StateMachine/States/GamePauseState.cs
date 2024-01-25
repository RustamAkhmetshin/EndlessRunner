using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GamePauseState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Services _services;

        public GamePauseState(GameStateMachine gameStateMachine, Services services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
        }
        
        public void Enter()
        {
            Time.timeScale = 0;
            
            Window window = _services.GetService<IWindowService>().OpenWindow(WindowId.PauseGameWindow);
            
            if (window is PauseWindow pauseWindow)
            {
                pauseWindow.SetResumeButtonCallback(() => { _gameStateMachine.Enter<GameplayState>(); });
                pauseWindow.SetQuitButtonCallback(() =>
                {
                    //Cleanup
                    Application.Quit();
                });
            }
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _services.GetService<IWindowService>().CloseWindow(WindowId.PauseGameWindow);
        }
    }
}