using UI;
using UI.Windows;
using UnityEngine;

namespace Core
{
    public class GamePauseState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Services _services;
        private PauseWindow _pauseWindow;
        
        public GamePauseState(StateMachine stateMachine, Services services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }
        
        public void Enter()
        {
            Time.timeScale = 0;
            _pauseWindow = (PauseWindow) _services.GetService<IWindowService>().OpenWindow(WindowId.PauseGameWindow);
            _pauseWindow.SetResumeButtonCallback(() => { _stateMachine.Enter<GameplayState>(); });
            _pauseWindow.SetQuitButtonCallback(() =>
            {
                //Cleanup
                Application.Quit();
            });
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _services.GetService<IWindowService>().CloseWindow(WindowId.PauseGameWindow);
        }
    }
}