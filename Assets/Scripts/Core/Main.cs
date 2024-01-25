using UnityEngine;

namespace Core
{
    //Entry point. Initializes the main state machine for the global states of the application.
    
    //Точка входа. Создается основная стейт-машина глобальных состояний приложения.
    
    
    public class Main : MonoBehaviour, ICoroutineRunner
    {
        public static Main Instance;
        
        private Game _game;
        
        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
            
            _game = new Game(this);
            _game.GameStateMachine.Enter<InitialState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
