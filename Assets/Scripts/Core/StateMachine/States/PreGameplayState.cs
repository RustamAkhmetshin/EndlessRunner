using Configs;
using Gameplay;
using Gameplay.Spawners;
using UI;
using UI.Windows;

namespace Core
{
    public class PreGameplayState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly Services _services;

        private CharacterView _characterView;

        public PreGameplayState(StateMachine stateMachine, ISceneLoader sceneLoader, Services services)
        {
            _stateMachine = stateMachine;
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
            
            StarterWindow starterWindow = (StarterWindow) _services.GetService<IWindowService>().OpenWindow(WindowId.StarterWindow);
            starterWindow.SetButtonCallback(() => { _stateMachine.Enter<GameplayState>(); });
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