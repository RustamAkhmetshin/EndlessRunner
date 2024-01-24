

using Configs;
using Core.EventBus;
using UI;

namespace Core
{
    public class InitialState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly Services _services;
        
        public InitialState(StateMachine stateMachine, ISceneLoader sceneLoader, Services services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }
        
        public void Enter()
        {
            _sceneLoader.Load(Constants.InitialSceneName, LoadGameLevel);
        }

        private void RegisterServices()
        {
            _services.RegisterService<IInputService>(new InputService());
            _services.RegisterService<IGameFactory>(new GameFactory());
            _services.RegisterService<IEventBusService>(new EventBusService());
            _services.RegisterService<IUIFactory>(new UIFactory());
            _services.RegisterService<IWindowService>(new WindowService(_services.GetService<IUIFactory>()));
        }

        private void LoadGameLevel()
        {
            _stateMachine.Enter<PreGameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}