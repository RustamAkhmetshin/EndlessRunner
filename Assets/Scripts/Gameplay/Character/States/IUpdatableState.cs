using Core;

namespace Gameplay.Character.States
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}