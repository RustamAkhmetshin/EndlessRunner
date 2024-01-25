

namespace Core
{
    public class Game
    {
        public GameStateMachine GameStateMachine;
        
        public Game(ICoroutineRunner coroutineRunner)
        {
            ISceneLoader sceneLoader = new SceneLoader(coroutineRunner);
            GameStateMachine = new GameStateMachine(sceneLoader,coroutineRunner, Services.Instance);
        }
    }
}