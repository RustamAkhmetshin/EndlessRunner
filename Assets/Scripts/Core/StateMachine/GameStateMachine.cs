using System;
using System.Collections.Generic;
using Gameplay.Character.States;

namespace Core
{
    public class GameStateMachine : BaseStateMachine
    {
        public GameStateMachine(ISceneLoader sceneLoader, ICoroutineRunner coroutineRunner, Services services)
        {
            AddState(new InitialState(this, sceneLoader, services));
            AddState(new PreGameplayState(this, sceneLoader, services));
            AddState(new GameplayState(this, coroutineRunner, services));
            AddState(new GamePauseState(this, services));
            AddState(new GameOverState(this, services));
        }
    }
}