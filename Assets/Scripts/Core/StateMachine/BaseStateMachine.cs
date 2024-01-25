using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class BaseStateMachine
    {
        protected Dictionary<Type, IState> _states;
        
        protected IState _activeState;

        protected BaseStateMachine()
        {
            _states = new Dictionary<Type, IState>();
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        protected TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        protected TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }

        protected void AddState<TState>(TState state) where TState : class, IState
        {
            _states[typeof(TState)] = state;
        }
    }
}