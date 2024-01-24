using UnityEngine;

namespace UI.Windows
{
    //Window base class
    
    //Базовый класс окна
    
    public abstract class Window : MonoBehaviour
    {
        private void Start()
        {
            Init();
        }

        public void CloseWindow()
        {
            Cleanup();
            Destroy(gameObject);
        }

        protected virtual void Init(){}
        protected virtual void Cleanup(){}
    }
}
