using Configs;
using UI.Windows;
using UnityEngine;

namespace UI
{
    //UI Elements Factory
    
    //Фабрика UI элементов
    
    public class UIFactory : IUIFactory
    {

        public UIFactory()
        {
            
        }
        
        public Window CreateStarterPopUp()
        {
            Window prefab = Resources.Load<Window>(Constants.UIStarterWindowPath);
            return InstantiateWindow(prefab);
        }

        public Window CreatePauseGameWindow()
        {
            Window prefab = Resources.Load<Window>(Constants.UIPauseWindowPath);
            return InstantiateWindow(prefab);
        }

        public Window CreateGameplayUI()
        {
            Window prefab = Resources.Load<Window>(Constants.UIGameplayPath);
            return InstantiateWindow(prefab);
        }

        public Window CreateGameOverWindow()
        {
            Window prefab = Resources.Load<Window>(Constants.UIGamepoverPath);
            return InstantiateWindow(prefab);
        }

        private Window InstantiateWindow(Window prefab)
        {
            if (prefab == null) return null;
            
            Window instance = Object.Instantiate(prefab);
            return instance;
        }
    }
}