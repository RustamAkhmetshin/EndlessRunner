using Configs;
using Gameplay.Character;
using UI;
using UI.Windows;

namespace Core
{
    public class PreGameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly Services _services;

        private CharacterView _characterView;

        public PreGameplayState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, Services services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
        }
        
        public void Enter()
        {
            _sceneLoader.Load(Constants.GameplaySceneName, OnSceneLoaded, true);
        }

        private void OnSceneLoaded()
        {
            LoadGameWorld();
            LoadCharacter();
            
            Window window = _services.GetService<IWindowService>().OpenWindow(WindowId.StarterWindow);

            if (window is StarterWindow starterWindow)
            {
                starterWindow.SetButtonCallback(() => { _gameStateMachine.Enter<GameplayState>(); });
            }
        }
        
        private void LoadGameWorld()
        {
            _services.GetService<IGameFactory>().CreateBackground();
            _services.GetService<IGameFactory>().CreateGround();
        }

        private void LoadCharacter()
        {
            _characterView = _services.GetService<IGameFactory>().CreateCharacter();
        }

        public void Exit()
        {
            _services.GetService<IWindowService>().CloseWindow(WindowId.StarterWindow);
            _characterView.GetCharacterController().StartRunning();
        }
    }
}