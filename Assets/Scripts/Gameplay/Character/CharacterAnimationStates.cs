using UnityEngine;

namespace Gameplay
{
    public static class CharacterAnimationStates
    {
        public static readonly int RunStateHash = Animator.StringToHash("CharacterRun");
        public static readonly int TakeOffStateHash = Animator.StringToHash("CharacterTakeOff");
        public static readonly int LandingStateHash = Animator.StringToHash("CharacterLanding");
        public static readonly int FallingStateHash = Animator.StringToHash("CharacterFalling");
        public static readonly int DeathStateHash = Animator.StringToHash("CharacterDeath");
        public static readonly int SlideStateHash = Animator.StringToHash("CharacterSlide");
        public static readonly int FlyStateHash = Animator.StringToHash("CharacterFly");
        public static readonly int IdleStateHash = Animator.StringToHash("CharacterIdle");
    }
}