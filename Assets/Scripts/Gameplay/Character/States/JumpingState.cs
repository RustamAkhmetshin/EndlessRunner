using UnityEngine;
using Vector2 = Core.Helpers.Vector2;

namespace Gameplay.Character.States
{
    public class JumpingState : IUpdatableState
    {
        private readonly CharacterStateMachine _stateMachine;
        private Character _character;
        private float _verticalSpeed;
        private bool _isJumping = false;
        
        private const float Gravity = -9.8f;
        
        public JumpingState(CharacterStateMachine stateMachine, Character character)
        {
            _stateMachine = stateMachine;
            _character = character;
        }
        
        public void Enter()
        {
            _isJumping = true;
            _verticalSpeed = _character.GetSettings().JumpStrength;
        }

        public void Exit()
        {
            _isJumping = false;
        }

        public void Update(float deltaTime)
        {
            if(!_isJumping) return;

            float newX = _character.Position.x + _character.Speed * deltaTime;
            float newY = _character.Position.y;
            
            newY += _verticalSpeed * deltaTime;
            _verticalSpeed += Gravity * _character.GetSettings().GravityScale * deltaTime;
            
            if (newY <= 0)
            {
                _verticalSpeed = 0;
                _stateMachine.Enter<RunningState>();
                return;
            }

            _character.Position = new Vector2(newX, newY);
        }
    }
}