using UnityEngine;
using CharacterController = Gameplay.Character.CharacterController;

namespace Gameplay
{
    //The main interface for an effect.
    
    //Основной интерфейс эффекта. 
    
    public interface IEffect
    {
        float Duration { get; }
        void Add(CharacterController characterController); //Добавление эффекта на объект (перед использованием)
        void RemoveEffect(CharacterController characterController); //Удаление эффекта
        void ApplyEffect(CharacterController characterController); // Активация логики эффекта
    }
}