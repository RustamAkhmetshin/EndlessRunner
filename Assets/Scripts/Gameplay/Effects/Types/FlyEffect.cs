
using System.Collections;
using Core;
using Core.Helpers;
using Gameplay.Character;
using UnityEngine;
using CharacterController = Gameplay.Character.CharacterController;


namespace Gameplay.Effects
{
    public class FlyEffect : IColoredEffect
    {
        public float Duration { get; }
        public string ColorHex { get; }

        private float _height;
        private float _riseDuration;
        
        private readonly ICoroutineRunner _coroutineRunner;

        public FlyEffect(ICoroutineRunner coroutineRunner)
        {
            var settings = Services.Instance.GetService<IConfigsLoader>().GetFlyEffectSettings();
            
            Duration = settings.Duration;
            ColorHex = settings.ColorHex;
            _height = settings.Height;
            _riseDuration = settings.RiseDuration;

            _coroutineRunner = coroutineRunner;
        }

        public void Add(CharacterController characterController)
        {
            characterController.AddEffect(this);
        }

        public void RemoveEffect(CharacterController characterController)
        {
            characterController.RemoveEffect(this);
        }

        public void ApplyEffect(CharacterController characterController)
        {
            _coroutineRunner.StartCoroutine(FlyCoroutine(characterController));
            characterController.GetCharacterView().characterAnimator.PlayAnimation(CharacterAnimationStates.FlyStateHash);
        }

        public Color GetColor()
        {
            if (ColorUtility.TryParseHtmlString(ColorHex, out var result))
            {
                return result;
            }
            
            return Color.white;
        }

        private IEnumerator FlyCoroutine(CharacterController characterController)
        {
            float startTime = Time.time;
            Vector3 startPosition = characterController.GetCharacter().Position.ToUnityVector2();
            Vector3 endPosition = new Vector3(startPosition.x, _height, startPosition.z);
            
            while (Time.time < startTime + _riseDuration)
            {
                float t = (Time.time - startTime) / _riseDuration;
                Vector3 newPosition = new Vector3(characterController.GetCharacter().Position.x, Mathf.Lerp(startPosition.y, endPosition.y, t), 0);
                characterController.GetCharacter().Position = newPosition.ToVector2Model();
                yield return null;
            }
            
            characterController.GetCharacter().Position = new Vector3(characterController.GetCharacter().Position.x, endPosition.y, 0).ToVector2Model();;

            yield return new WaitForSeconds(Duration);
            
            startTime = Time.time;
            
            while (Time.time < startTime + _riseDuration)
            {
                float t = (Time.time - startTime) / _riseDuration;
                Vector3 newPosition = new Vector3(characterController.GetCharacter().Position.x, Mathf.Lerp(endPosition.y, 0, t), 0);
                characterController.GetCharacter().Position = newPosition.ToVector2Model();;
                yield return null;
            }
            
            characterController.GetCharacter().Position = new Vector3(characterController.GetCharacter().Position.x, 0, 0).ToVector2Model();;
            
            RemoveEffect(characterController);
            characterController.GetCharacterView().characterAnimator.PlayAnimation(CharacterAnimationStates.RunStateHash);
        }
    }
}