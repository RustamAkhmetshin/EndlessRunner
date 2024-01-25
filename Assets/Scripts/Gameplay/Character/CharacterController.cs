using Configs.Character;
using Core;
using Core.EventBus;
using Core.Helpers;
using UnityEngine;

namespace Gameplay.Character
{
    //Character controller. Applying effects is done by delegating the logic to the effect class itself.
    
    //Контроллер персонажа. Наложение эффектов происходит путем делегирования логики в сам класс эффекта.
    
    public class CharacterController
    {
        private CharacterView _view;
        private Character _character;

        private readonly IInputService _inputService;
        private readonly IEventBusService _eventBusService;

        public CharacterController(CharacterView view, ICharacterSettings characterSettings)
        {
            _view = view;

            _character = new Character(characterSettings);
            _character.SpeedChanged += SpeedChanged;
            _character.Jump += _view.SetJump;
            
            _eventBusService = Services.Instance.GetService<IEventBusService>();
            _eventBusService.CreatePlayer(_view.transform);
            _eventBusService.ChangePlayerSpeed(_character.Speed);

            _inputService = Services.Instance.GetService<IInputService>();
            _inputService.OnJump += Jump;
        }

        public void Update(float deltaTime)
        {
            _inputService.Update();
            _character.Update(deltaTime);
            _view.UpdatePosition(_character.Position.ToUnityVector2());
        }

        public void StartRunning()
        {
            _character.SetOriginalSpeed();
            _character.SetRunningState();
            _inputService.Enable();
        }
        
        private void Jump()
        {
            _character.SetJumpState();
        }
        
        public void AddEffect(IEffect effect)
        {
            _character.SetRunningState();
            _character.AddEffect(effect);
            effect.ApplyEffect(this);
        }

        public void RemoveEffect(IEffect effect)
        {
           _character.RemoveEffect(effect);
        }
        
        public Character GetCharacter()
        {
            return _character;
        }

        public CharacterView GetCharacterView()
        {
            return _view;
        }

        private void SpeedChanged(float newSpeed)
        {
            _eventBusService.ChangePlayerSpeed(newSpeed);
            
            if(_character.IsGrounded())
                _view.SetRunningAnimationSpeed(newSpeed);
        }

        public void OnDestroy()
        {
            _inputService.OnJump -= Jump;
            _inputService.Disable();
            
            _character.SpeedChanged -= SpeedChanged;
            _character.Jump -= _view.SetJump;
        }
    }
}