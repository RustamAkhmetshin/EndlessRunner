using System.Collections.Generic;
using UI.Windows;
using UnityEngine;

namespace UI
{
    //A class for opening/closing windows retrieved from the factory.
    
    //Класс для открытия/закрытия окон, которые берутся из фабрики.
    
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;
        private Dictionary<WindowId, Window> _openedWindows;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _openedWindows = new Dictionary<WindowId, Window>();
        }

        public Window OpenWindow(WindowId id)
        {
            switch (id)
            {
                case WindowId.StarterWindow:
                    _openedWindows[WindowId.StarterWindow] = _uiFactory.CreateStarterPopUp();
                    return _openedWindows[WindowId.StarterWindow];

                case WindowId.PauseGameWindow:
                    _openedWindows[WindowId.PauseGameWindow] = _uiFactory.CreatePauseGameWindow();
                    return _openedWindows[WindowId.PauseGameWindow];
                
                case WindowId.GameplayUI:
                    _openedWindows[WindowId.GameplayUI] = _uiFactory.CreateGameplayUI();
                    return _openedWindows[WindowId.GameplayUI];
                
                case WindowId.GameoverWindow:
                    _openedWindows[WindowId.GameoverWindow] = _uiFactory.CreateGameOverWindow();
                    return _openedWindows[WindowId.GameoverWindow];
            }

            return null;
        }

        public void CloseWindow(WindowId id)
        {
            _openedWindows[id].CloseWindow();
        }
    }
}