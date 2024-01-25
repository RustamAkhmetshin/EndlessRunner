using Core;
using UnityEngine;

namespace Gameplay.Character.States
{
    public class IdleState : IState
    {
        private readonly CharacterStateMachine _stateMachine;
        
        public IdleState(CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            
        }

        public void Exit()
        {
           
        }
    }
}