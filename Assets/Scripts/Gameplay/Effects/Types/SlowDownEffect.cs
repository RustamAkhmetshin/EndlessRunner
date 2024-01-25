using System.Threading.Tasks;
using Core;
using UnityEngine;
using CharacterController = Gameplay.Character.CharacterController;


namespace Gameplay.Effects
{
    public class SlowDownEffect : SpeedChangingEffect, IColoredEffect
    {
        public string ColorHex { get; }
        
        
        public SlowDownEffect()
        {
            var settings = Services.Instance.GetService<IConfigsLoader>().GetSlowDownEffectSettings();
            
            Duration = settings.Duration;
            ColorHex = settings.ColorHex;
            _multiplier = settings.Multiplier;
        }
        
        public Color GetColor()
        {
            if (ColorUtility.TryParseHtmlString(ColorHex, out var result))
            {
                return result;
            }
            
            return Color.white;
        }
    }
}