using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay.Effects
{
    public class SlowDownEffect : IEffect
    {
        private float _multiplier = 2f;
        private int _duration = 2000;
        private string _colorHex = "#FF7FFC";
        
        private float _originalSpeed;

        public void Add(CharacterController characterController)
        {
            characterController.AddEffect(this);
        }

        public void Remove(CharacterController characterController)
        {
            characterController.GetCharacter().Speed = _originalSpeed;
            characterController.GetCharacter().RemoveEffect(this);
        }

        public async void StartEffect(CharacterController characterController)
        {
            _originalSpeed = characterController.GetCharacter().GetOriginalSpeed();
            characterController.GetCharacter().Speed *= (1 / _multiplier);

            await Task.Delay(_duration);
            Remove(characterController);
        }

        public Color GetColor()
        {
            if (ColorUtility.TryParseHtmlString(_colorHex, out var result))
            {
                return result;
            }
            
            Debug.Log(111);
            return Color.white;
        }
    }
}