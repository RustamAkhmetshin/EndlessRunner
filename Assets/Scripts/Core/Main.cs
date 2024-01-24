using UnityEngine;

namespace Core
{
    //Entry point. Initializes the main state machine for the global states of the application.
    
    //Точка входа. Создается основная стейт-машина глобальных состояний приложения.
    
    
    public class Main : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this);
            _game.stateMachine.Enter<InitialState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
