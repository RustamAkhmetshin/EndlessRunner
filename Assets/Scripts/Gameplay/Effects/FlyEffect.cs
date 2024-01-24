using System.Collections;
using System.Threading.Tasks;
using Core;
using UnityEngine;

namespace Gameplay.Effects
{
    public class FlyEffect : IEffect
    {
        private int _duration = 2;
        private float _height = 5f;
        private float _riseDuration = 0.5f;
        private string _colorHex = "#20FF15";
        
        private readonly ICoroutineRunner _coroutineRunner;

        public FlyEffect(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Add(CharacterController characterController)
        {
            characterController.AddEffect(this);
        }

        public void Remove(CharacterController characterController)
        {
            
            characterController.GetCharacter().RemoveEffect(this);
        }

        public async void StartEffect(CharacterController characterController)
        {
            _coroutineRunner.StartCoroutine(FlyCoroutine(characterController));
            characterController.GetCharacterView().characterAnimator.PlayAnimation(CharacterAnimationStates.FlyStateHash);
        }

        public Color GetColor()
        {
            if (ColorUtility.TryParseHtmlString(_colorHex, out var result))
            {
                return result;
            }
            
            return Color.white;
        }

        private IEnumerator FlyCoroutine(CharacterController characterController)
        {
            float startTime = Time.time;
            Vector3 startPosition = characterController.GetCharacter().Position;
            Vector3 endPosition = startPosition + new Vector3(0, _height, 0);
            
            while (Time.time < startTime + _riseDuration)
            {
                float t = (Time.time - startTime) / _riseDuration;
                Vector3 newPosition = new Vector3(characterController.GetCharacter().Position.x, Mathf.Lerp(startPosition.y, endPosition.y, t), 0);
                characterController.GetCharacter().Position = newPosition;
                yield return null;
            }
            
            characterController.GetCharacter().Position = new Vector3(characterController.GetCharacter().Position.x, endPosition.y, 0);

            yield return new WaitForSeconds(_duration);
            
            startTime = Time.time;
            
            while (Time.time < startTime + _riseDuration)
            {
                float t = (Time.time - startTime) / _riseDuration;
                Vector3 newPosition = new Vector3(characterController.GetCharacter().Position.x, Mathf.Lerp(endPosition.y, 0, t), 0);
                characterController.GetCharacter().Position = newPosition;
                yield return null;
            }
            
            characterController.GetCharacter().Position = new Vector3(characterController.GetCharacter().Position.x, startPosition.y, 0);
            
            Remove(characterController);
            characterController.GetCharacterView().characterAnimator.PlayAnimation(CharacterAnimationStates.RunStateHash);
        }
    }
}