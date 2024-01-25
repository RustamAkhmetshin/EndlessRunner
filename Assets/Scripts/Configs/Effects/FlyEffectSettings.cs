using UnityEngine;

namespace Configs.Effects
{
    [CreateAssetMenu(fileName = "FlyEffectSettings", menuName = "ScriptableObjects/FlyEffectSettings", order = 1)]
    public class FlyEffectSettings : ScriptableObject
    {
        [SerializeField] private float duration = 2f;
        [SerializeField] private float height = 5f;
        [SerializeField] private float riseDuration = 0.5f;
        [SerializeField] private string colorHex = "#FF7FFC";
        
        public float Duration => duration;

        public float Height => height;

        public float RiseDuration => riseDuration;

        public string ColorHex => colorHex;
    }
}
