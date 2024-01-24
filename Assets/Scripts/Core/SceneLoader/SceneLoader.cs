using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    //Scene loader. You can add a loading screen between scenes and pass progress.
    
    //Загрузчик сцен. Между сценами можно добавить экран загрузки и передавать прогресс.
    
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null, bool forceReload = false)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded, forceReload));
        }
        
        private IEnumerator LoadScene(string nextScene, Action onLoaded = null, bool forceReload = false)
        {
            if (!forceReload && SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }
    }
}