

namespace Core
{
    public class Game
    {
        public StateMachine stateMachine;
        
        public Game(ICoroutineRunner coroutineRunner)
        {
            ISceneLoader sceneLoader = new SceneLoader(coroutineRunner);
            stateMachine = new StateMachine(sceneLoader,coroutineRunner, Services.Instance);
        }
    }
}