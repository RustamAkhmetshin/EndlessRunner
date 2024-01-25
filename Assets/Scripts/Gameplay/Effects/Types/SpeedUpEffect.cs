using System.Threading.Tasks;
using Core;
using UnityEngine;
using CharacterController = Gameplay.Character.CharacterController;


namespace Gameplay.Effects
{
    public class SpeedUpEffect : SpeedChangingEffect, IColoredEffect
    {
        public string ColorHex { get; }
        
        
        public SpeedUpEffect()
        {
            var settings = Services.Instance.GetService<IConfigsLoader>().GetSpeedUpEffectSettings();
            
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