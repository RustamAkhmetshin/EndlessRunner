
namespace Gameplay
{
    public class Coin
    {
        private IEffect _effect;

        public Coin(IEffect effect = null)
        {
            _effect = effect;
        }

        public void InitEffect(IEffect effect)
        {
            _effect = effect;
        }

        public void Collect(CharacterController characterController)
        {
            _effect?.Add(characterController);
        }

        public void OnDestroy()
        {
            
        }
    }
}