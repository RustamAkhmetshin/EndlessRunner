using Configs.Character;
using Core;
using Core.EventBus;
using Core.Helpers;

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

        public CharacterController(CharacterView view, CharacterSettings characterSettings)
        {
            _view = view;

            _character = new Character(characterSettings);
            _character.OnSpeedChanged += OnSpeedChanged;
            
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
            SetOriginalSpeed();
            _inputService.Enable();
        }
        
        public void AddEffect(IEffect effect)
        {
            _character.AddEffect(effect);
            effect.StartEffect(this);
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

        public void OnDestroy()
        {
            _inputService.OnJump -= Jump;
            _inputService.Disable();
            
            _character.OnSpeedChanged -= OnSpeedChanged;
            _character.OnDestroy();
        }

        private void OnSpeedChanged(float newSpeed)
        {
            _eventBusService.ChangePlayerSpeed(newSpeed);
            _view.OnSpeedChanged(newSpeed);
        }

        private void SetOriginalSpeed()
        {
            _character.SetOriginalSpeed();
        }
        
        private void Jump()
        {
            if (_character.IsJumping || _character.Position.y > 0)
                return;
            
            _character.Jump();
            _view.SetJump();
        }
    }
}