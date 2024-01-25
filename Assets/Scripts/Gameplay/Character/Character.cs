using System.Collections.Generic;
using Configs.Character;
using Core.Helpers;
using Gameplay.Character.States;

namespace Gameplay.Character
{
    //Main character model. Controlled by a controller and sends data to the view.
    
    //Модель главного персонажа. Управляется контроллером и передает данные в представление. 
    
    public class Character
    {
        public delegate void CharacterDelegate();
        public delegate void CharacterSpeedDelegate(float speed);
        public event CharacterDelegate Jump;
        public event CharacterSpeedDelegate SpeedChanged;
        
        public Vector2 Position { get; set; }

        public float Speed
        {
            get => _speed; 
            set
            {
                _speed = value;
                SpeedChanged?.Invoke(_speed);
            }
        }

        private CharacterStateMachine _stateMachine;
        private float _speed;
        private List<IEffect> _activeEffects = new List<IEffect>();
        private readonly ICharacterSettings _settings;
        

        public Character(ICharacterSettings settings)
        {
            _settings = settings;
            Speed = 0;
            Position = new Vector2(0, 0);
            
            _stateMachine = new CharacterStateMachine(this);
            _stateMachine.Enter<IdleState>();
        }

        public void Update(float deltaTime)
        {
            _stateMachine.Update(deltaTime);
        }

        public void SetIdleState()
        {
            _stateMachine.Enter<IdleState>();
        }
        
        public void SetJumpState()
        {
            if(!IsGrounded()) return;
            
            _stateMachine.Enter<JumpingState>();
            Jump?.Invoke();
        }
        
        public void SetRunningState()
        {
            _stateMachine.Enter<RunningState>();
        }

        public void SetOriginalSpeed()
        {
            Speed = _settings.OriginalSpeed;
        }

        public bool IsGrounded()
        {
            return Position.y <= 0;
        }

        public void AddEffect(IEffect effect)
        {
            _activeEffects.Add(effect);
        }

        public void RemoveEffect(IEffect effect)
        {
            _activeEffects.Remove(effect);
        }

        public ICharacterSettings GetSettings()
        {
            return _settings;
        }
    }
}