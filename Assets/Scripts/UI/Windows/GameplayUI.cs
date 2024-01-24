using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameplayUI : Window
    {
        [SerializeField] private Button pauseButton;

        protected override void Cleanup()
        {
            pauseButton.onClick.RemoveAllListeners();
        }
        
        public void SetButtonCallback(UnityAction callback)
        {
            pauseButton.onClick.AddListener(callback);
        }
    }
}