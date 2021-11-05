using _Project.Data.Scripts;
using UnityEngine;

namespace _Project.Navigation.Scripts
{
    public abstract class Screen : MonoBehaviour
    {
        #region Lifecyle

        protected void Awake() => _canvas = FindObjectsOfType<Canvas>();

        private void Start()
        {
            foreach (var canvas in _canvas)
            {
                canvas.sortingOrder = NavigationController.Instance.ScreensAmount;
            }
        }

        #endregion

        private Canvas[] _canvas;
    }

    public abstract class Screen<T> : MonoBehaviour
        where T : struct
    {
        #region Lifecycle

        protected void Awake() => _canvas = FindObjectsOfType<Canvas>();

        private void Start()
        {
            foreach (var canvas in _canvas)
            {
                canvas.sortingOrder = NavigationController.Instance.ScreensAmount;
            }

            var data = DataController<T>.Get();
            Initialize(data);
        }

        #endregion

        protected abstract void Initialize(T value);

        private Canvas[] _canvas;
    }
}
