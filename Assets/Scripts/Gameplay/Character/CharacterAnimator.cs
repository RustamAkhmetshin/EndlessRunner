using System;
using UnityEngine;

namespace Gameplay.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation(int stateHash, float speed = 1)
        {
            _animator.Play(stateHash);
            _animator.speed = speed;
        }
    }
}