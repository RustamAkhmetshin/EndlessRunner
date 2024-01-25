
using Core;
using Gameplay.Character;
using UnityEngine;

namespace Gameplay
{
    public class CoinView : MonoBehaviour
    {
        private Transform _cameraTransform;
        private CoinController _coinController;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _coinController = new CoinController(this);
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            if (transform.position.x < _cameraTransform.position.x - Screen.width / 200f)
            {
                Services.Instance.GetService<IGameFactory>().DisableCoin(this);
            }
        }

        public void InitEffect(IEffect effect)
        {
            _coinController.InitEffect(effect);
            SetColor(effect.GetColor());
        }

        
        //Метод для модификации представления для разных типов эффектов.
        
        private void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CharacterView characterView = other.GetComponent<CharacterView>();
            if(characterView == null) return;

            _coinController.CollectCoin(characterView.GetCharacterController());
        }
    }
}
