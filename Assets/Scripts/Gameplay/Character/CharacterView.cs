using System;
using Configs;
using Configs.Character;
using Core;
using Core.EventBus;
using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterView : MonoBehaviour
    {
        private const float AnimationMultiplier = 6f; //Переменная для контроля скорости анимации бега при изменении параметров
        
        [SerializeField] private CharacterSettings settings;
        
        public CharacterAnimator characterAnimator;
        
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = new CharacterController(this, settings);
            characterAnimator = GetComponent<CharacterAnimator>();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }

        public void SetJump()
        {
            characterAnimator.PlayAnimation(CharacterAnimationStates.TakeOffStateHash);
        }

        public void SetRun(float speed)
        {
            characterAnimator.PlayAnimation(CharacterAnimationStates.RunStateHash, speed);
            
        }

        public void SetSlide()
        {
            characterAnimator.PlayAnimation(CharacterAnimationStates.SlideStateHash);
        }

        public CharacterController GetCharacterController()
        {
            return _characterController;
        }

        public void OnSpeedChanged(float newSpeed)
        {
            if (newSpeed > 0)
            {
                SetRun(newSpeed / AnimationMultiplier);
            }
        }

        private void OnDestroy()
        {
            _characterController.OnDestroy();
        }
    }
}
