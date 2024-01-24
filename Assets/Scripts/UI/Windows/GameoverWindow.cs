using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameoverWindow : Window
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button quitButton;
        
        protected override void Cleanup()
        {
            retryButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
        }

        public void SetRetryButtonCallback(UnityAction callback)
        {
            retryButton.onClick.AddListener(callback);
        }
        
        public void SetQuitButtonCallback(UnityAction callback)
        {
            quitButton.onClick.AddListener(callback);
        }
    }
}