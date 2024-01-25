using Configs;
using Configs.Effects;
using UnityEngine;

namespace Core
{
    public class ConfigsLoader : IConfigsLoader
    {
        public SpeedUpEffectSettings GetSpeedUpEffectSettings()
        {
            SpeedUpEffectSettings settingsAsset = Resources.Load<SpeedUpEffectSettings>(ConfigsPath.SpeedUpEffectSettingsPath);
            if (settingsAsset == null)
            {
                Debug.Log($"No SpeedUpEffectSettings asset at path: {ConfigsPath.SpeedUpEffectSettingsPath}" );
                return null;
            }

            return settingsAsset;
        }
        
        public SlowDownEffectSettings GetSlowDownEffectSettings()
        {
            SlowDownEffectSettings settingsAsset = Resources.Load<SlowDownEffectSettings>(ConfigsPath.SlowDownEffectSettingsPath);
            if (settingsAsset == null)
            {
                Debug.Log($"No SlowDownEffectSettings asset at path: {ConfigsPath.SlowDownEffectSettingsPath}" );
                return null;
            }

            return settingsAsset;
        }
        
        public FlyEffectSettings GetFlyEffectSettings()
        {
            FlyEffectSettings settingsAsset = Resources.Load<FlyEffectSettings>(ConfigsPath.FlyEffectSettingsPath);
            if (settingsAsset == null)
            {
                Debug.Log($"No FlyEffectSettings asset at path: {ConfigsPath.FlyEffectSettingsPath}" );
                return null;
            }

            return settingsAsset;
        }
    }
}