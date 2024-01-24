using Core;
using UI.Windows;

namespace UI
{
    public interface IUIFactory : IService
    {
        Window CreateStarterPopUp();
        Window CreatePauseGameWindow();
        Window CreateGameplayUI();
        Window CreateGameOverWindow();
    }
}