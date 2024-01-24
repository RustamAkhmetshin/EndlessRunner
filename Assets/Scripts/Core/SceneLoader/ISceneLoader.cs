using System;

namespace Core
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null, bool forceReload = false);
    }
}