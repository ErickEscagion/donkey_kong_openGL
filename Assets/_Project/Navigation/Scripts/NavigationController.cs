using System.Collections.Generic;
using _Project.Data.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Navigation.Scripts
{
    public class NavigationController : MonoBehaviour
    {
        #region Properties

        public static NavigationController Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                var nav = Resources.Load<NavigationController>("_navigationController");
                Instantiate(nav, Vector3.zero, Quaternion.identity);

                return _instance;
            }
        }

        internal int ScreensAmount => _scenes.Count;

        #endregion

        #region Public static methods

        public static AsyncOperation Push(string sceneName, LoadSceneMode mode)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName, mode);
            Instance._scenes.Push(sceneName);
            return operation;
        }

        public static AsyncOperation Push<T>(string sceneName, LoadSceneMode mode, T data)
            where T : struct
        {
            var operation = SceneManager.LoadSceneAsync(sceneName, mode);
            DataController<T>.Add(data);
            Instance._scenes.Push(sceneName);
            return operation;
        }

        public static AsyncOperation Pop(string sceneName)
        {
            var operation = SceneManager.UnloadSceneAsync(sceneName);
            Instance._scenes.Pop();
            return operation;
        }

        #endregion

        #region Lifecycle

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                _scenes.Push(SceneManager.GetActiveScene().name);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        private static NavigationController _instance;
        private readonly Stack<string> _scenes = new Stack<string>();
    }
}
