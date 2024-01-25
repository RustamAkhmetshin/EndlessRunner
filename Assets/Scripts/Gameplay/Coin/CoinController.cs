using Core;
using Gameplay.Character;

namespace Gameplay
{
    public class CoinController
    {
        private Coin _coin;
        private CoinView _view;
        
        public CoinController(CoinView coinView)
        {
            _view = coinView;
            _coin = new Coin();
        }

        public void InitEffect(IEffect effect)
        {
            _coin.InitEffect(effect);
        }

        public void CollectCoin(CharacterController characterController)
        {
            _coin.Collect(characterController);
            Services.Instance.GetService<IGameFactory>().DisableCoin(_view);
        }
    }
}