using UnityEngine;

namespace Configs.Effects
{
    [CreateAssetMenu(fileName = "SlowDownEffectSettings", menuName = "ScriptableObjects/SlowDownEffectSettings", order = 1)]
    public class SlowDownEffectSettings : ScriptableObject
    {
        [SerializeField] private float multiplier = 0.5f;
        [SerializeField] private float duration = 2f;
        [SerializeField] private string colorHex = "#FF7FFC";

        public float Multiplier => multiplier;
        public float Duration => duration;
        public string ColorHex => colorHex;
    }
}
