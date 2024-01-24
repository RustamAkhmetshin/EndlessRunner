using UnityEngine;

namespace Gameplay
{
    //The main interface for an effect.
    
    //Основной интерфейс эффекта. 
    
    public interface IEffect
    {
        void Add(CharacterController characterController);
        void Remove(CharacterController characterController);
        void StartEffect(CharacterController characterController);
        Color GetColor();
    }
}