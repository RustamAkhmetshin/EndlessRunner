using Configs.Effects;

namespace Core
{
    // Сервис загрузки конфигов для эффектов
    
    public interface IConfigsLoader : IService
    {
        SpeedUpEffectSettings GetSpeedUpEffectSettings();
        SlowDownEffectSettings GetSlowDownEffectSettings();
        FlyEffectSettings GetFlyEffectSettings();
    }
}