using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Effects
{
    public class EffectsContainer : IEffectsContainer
    {
        public Dictionary<string, IEffect> EfectsList { get; }

        public EffectsContainer()
        {
            EfectsList = new Dictionary<string, IEffect>();
        }

        public void AddEffect(string name, IEffect effect)
        {
            if (EfectsList != null)
            {
                EfectsList[name] = effect;
            }
        }

        public IEffect GetRandomEffect()
        {
            Random rand = new Random();
            return EfectsList.ElementAt(rand.Next(0, EfectsList.Count)).Value;
        }

        public IEffect GetEffectByName(string name)
        {
            return EfectsList[name];
        }
    }
}