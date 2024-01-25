using System.Collections.Generic;

namespace Gameplay.Effects
{
    
    //Простой контейнер эффектов для спавна
    
    public interface IEffectsContainer
    {
        Dictionary<string, IEffect> EfectsList { get; }
        void AddEffect(string name, IEffect effect);
        IEffect GetRandomEffect();
        IEffect GetEffectByName(string name);
    }
}