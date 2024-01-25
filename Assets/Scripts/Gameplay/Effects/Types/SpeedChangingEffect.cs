using System.Threading.Tasks;
using UnityEngine;
using CharacterController = Gameplay.Character.CharacterController;

namespace Gameplay.Effects
{
    public class SpeedChangingEffect : IEffect
    {
        public float Duration { get; set; }
        
        protected float _multiplier;
        private float _originalSpeed;
        
        public void Add(CharacterController characterController)
        {
            characterController.AddEffect(this);
        }

        public void RemoveEffect(CharacterController characterController)
        {
            characterController.GetCharacter().Speed = _originalSpeed;
            characterController.RemoveEffect(this);
        }

        public async void ApplyEffect(CharacterController characterController)
        {
            _originalSpeed = characterController.GetCharacter().GetSettings().OriginalSpeed;
            characterController.GetCharacter().Speed *= _multiplier;

            await Task.Delay((int)Duration * 1000);
            RemoveEffect(characterController);
        }
    }
}