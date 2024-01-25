using UnityEngine;

namespace Gameplay.Effects
{
    // Интерфейс для подтипа представлений эффектов, которые используют изменение цвета спрайта 
    
    public interface IColoredEffect : IEffect
    {
        string ColorHex { get; }
        Color GetColor();
    }
}