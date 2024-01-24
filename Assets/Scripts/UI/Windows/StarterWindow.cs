using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Windows
{
    public class StarterWindow : Window
    {
        [SerializeField] private Button startButton;

        protected override void Cleanup()
        {
            startButton.onClick.RemoveAllListeners();
        }

        public void SetButtonCallback(UnityAction callback)
        {
            startButton.onClick.AddListener(callback);
        }
    }
}