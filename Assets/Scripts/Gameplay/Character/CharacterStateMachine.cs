using System;
using System.Collections.Generic;
using Configs.Character;
using Core;
using Gameplay.Character.States;

namespace Gameplay.Character
{
    public class CharacterStateMachine : BaseStateMachine
    {
        private readonly ICharacterSettings _settings;
        private Dictionary<Type, IUpdatableState> _updatableStates;

        public CharacterStateMachine(Character character)
        {
            _updatableStates = new Dictionary<Type, IUpdatableState>();
            _settings = character.GetSettings();
            
            AddState(new IdleState(this));
            
            AddUpdatableState(new JumpingState(this, character));
            AddUpdatableState(new RunningState(this, character));
        }
        
        protected void AddUpdatableState<TState>(TState state) where TState : class, IUpdatableState
        {
            AddState(state);
            _updatableStates[typeof(TState)] = state;
        }

        public void Update(float deltaTime)
        {
            foreach (var state in _updatableStates)
            {
                state.Value.Update(deltaTime);
            }
        }
    }
}