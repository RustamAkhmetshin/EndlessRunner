using UnityEngine;

namespace Configs.Effects
{
    //Configuration file for the effects
    
    //Файл конфигурации для эффекта 
    
    [CreateAssetMenu(fileName = "SpeedUpEffectSettings", menuName = "ScriptableObjects/SpeedUpEffectSettings", order = 1)]
    public class SpeedUpEffectSettings : ScriptableObject
    {
        [SerializeField] private float multiplier = 2f;
        [SerializeField] private float duration = 2f;
        [SerializeField] private string colorHex = "#A61E17";

        public float Multiplier => multiplier;
        public float Duration => duration;
        public string ColorHex => colorHex;
    }
}
