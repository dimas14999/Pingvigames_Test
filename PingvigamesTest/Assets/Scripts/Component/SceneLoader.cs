using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Component
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        // Лучше использовать DI, к примеру Zenject
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void Load(string name, Action onLoaded = null) =>
            StartCoroutine(LoadScene(name, onLoaded));
    
        private static IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }
    }
}