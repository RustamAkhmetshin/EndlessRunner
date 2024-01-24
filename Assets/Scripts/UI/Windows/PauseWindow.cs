using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Windows
{
    public class PauseWindow : Window
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;
        
        protected override void Cleanup()
        {
            resumeButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
        }

        public void SetResumeButtonCallback(UnityAction callback)
        {
            resumeButton.onClick.AddListener(callback);
        }
        
        public void SetQuitButtonCallback(UnityAction callback)
        {
            quitButton.onClick.AddListener(callback);
        }
    }
}