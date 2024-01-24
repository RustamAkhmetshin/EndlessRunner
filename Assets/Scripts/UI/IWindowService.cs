using Core;
using UI.Windows;

namespace UI
{
    public interface IWindowService : IService
    {
        Window OpenWindow(WindowId id);
        void CloseWindow(WindowId id);
    }
}