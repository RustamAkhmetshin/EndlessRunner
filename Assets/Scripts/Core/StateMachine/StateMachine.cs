using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Core
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public StateMachine(ISceneLoader sceneLoader, ICoroutineRunner coroutineRunner, Services services)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(InitialState)] = new InitialState(this, sceneLoader, services),
                [typeof(PreGameplayState)] = new PreGameplayState(this, sceneLoader, services),
                [typeof(GameplayState)] = new GameplayState(this, coroutineRunner, services),
                [typeof(GamePauseState)] = new GamePauseState(this, services),
                [typeof(GameOverState)] = new GameOverState(this, services),
            };
        }
    
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
      
            TState state = GetState<TState>();
            _activeState = state;
      
            return state;
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}