using UnityEngine;
using Vector2 = Core.Helpers.Vector2;

namespace Gameplay.Character.States
{
    public class RunningState : IUpdatableState
    {
        private readonly CharacterStateMachine _stateMachine;
        private Character _character;
        private bool _isRunning = false;
        
        public RunningState(CharacterStateMachine stateMachine, Character character)
        {
            _stateMachine = stateMachine;
            _character = character;
        }
        
        public void Enter()
        {
            _character.Position = new Vector2(_character.Position.x, 0);
            _isRunning = true;
        }

        public void Exit()
        {
            _isRunning = false;
        }

        public void Update(float deltaTime)
        {
            if (!_isRunning) return;
            
            float newX = _character.Position.x + _character.Speed * deltaTime;
            _character.Position = new Vector2(newX, _character.Position.y);
        }
    }
}