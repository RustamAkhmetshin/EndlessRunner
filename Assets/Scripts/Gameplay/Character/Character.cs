using System.Collections.Generic;
using Configs.Character;
using UnityEngine;

namespace Gameplay
{
    //Main character model. Controlled by a controller and sends data to the view.
    
    //Модель главного персонажа. Управляется контроллером и передает данные в представление. 
    
    public class Character
    {
        public delegate void CharacterSpeedDelegate(float speed);
        public event CharacterSpeedDelegate OnSpeedChanged;
        
        public Vector2 Position { get; set; }

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnSpeedChanged?.Invoke(_speed);
            }
        }
        
        public bool IsBusy { get; private set; }
        public bool IsJumping { get; private set; }
        
        private Vector2 _position;
        private float _speed;
        private List<IEffect> _activeEffects = new List<IEffect>();
        private CharacterSettings _settings;
        private float _verticalSpeed;
        
        private const float Gravity = -9.8f;

        public Character(CharacterSettings settings)
        {
            Speed = 0;
            _settings = settings;
        }

        public float GetOriginalSpeed()
        {
            return _settings.OriginalSpeed;
        }
        
        public void Update(float deltaTime)
        {
            float newX = Position.x + Speed * deltaTime;
            float newY = Position.y;
            
            if (IsJumping)
            {
                newY += _verticalSpeed * deltaTime;
                _verticalSpeed += Gravity * _settings.GravityScale * deltaTime;
            }
            
            if (newY <= 0)
            {
                newY = 0;
                IsJumping = false;
                _verticalSpeed = 0;
            }

            Position = new Vector2(newX, newY);
        }

        public void AddEffect(IEffect effect)
        {
            IsBusy = true;
            _activeEffects.Add(effect);
        }

        public void RemoveEffect(IEffect effect)
        {
            _activeEffects.Remove(effect);
            IsBusy = false;
        }

        public void SetOriginalSpeed()
        {
            Speed = _settings.OriginalSpeed;
        }
        
        public void Jump()
        {
            IsJumping = true;
            _verticalSpeed = _settings.JumpStrength;
        }
        
        public void OnDestroy()
        {
            
        }
    }
}