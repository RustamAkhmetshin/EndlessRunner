using UnityEngine;

namespace Configs.Character
{
    //Configuration/settings file for character values (located in the Config folder).
    
    //Файл конфигурации/настроек значений персонажа (находится в папке Config)
    
    
    [CreateAssetMenu(fileName = "CharacterSettings", menuName = "ScriptableObjects/CharacterSettings", order = 1)]
    public class CharacterSettings : ScriptableObject, ICharacterSettings
    {
        [SerializeField] private float originalSpeed;
        [SerializeField] private float jumpStrength;
        [SerializeField] private float gravityScale;
        
        public float OriginalSpeed => originalSpeed;
        public float JumpStrength => jumpStrength;
        public float GravityScale => gravityScale;
    }
}


