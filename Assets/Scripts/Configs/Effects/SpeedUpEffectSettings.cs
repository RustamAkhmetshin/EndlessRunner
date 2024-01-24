using UnityEngine;

namespace Configs.Effects
{
    //Configuration file for the effects - incomplete. The idea was to create a factory for effects configurations and modify their parameters in the editor.
    
    //Файл конфигурации для эффекта - не закончен, идея заключалась в том, чтобы создать фабрику для конфигураций эффектов и менять их параметры в эдиторе
    
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
