using System;

namespace Core
{
    public interface IInputService : IService
    {
        event Action OnJump;
        event Action OnSlide;
        void Enable();
        void Disable();
        void Update();
    }
}