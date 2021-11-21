using System;
using _Project.Data.Scripts;
using _Project.Navigation.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Screen = _Project.Navigation.Scripts.Screen;

namespace _Project.Levels._Shared.Scripts
{
    public abstract class LevelController : Screen
    {
        #region Properties

        protected abstract string SceneName { get; }

        #endregion

        #region Lifecycle

        private void OnEnable() => DataEvent<LevelState>.call += OnLevelStateChange;

        private void OnDisable() => DataEvent<LevelState>.call -= OnLevelStateChange;

        #endregion

        private void OnLevelStateChange(LevelState state)
        {
            switch (state)
            {
                case LevelState.Defeat:
                    level.Deaths++;
                    NavigationController.Navigate(SceneName, LoadSceneMode.Single);
                    break;
                case LevelState.Victory:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

#pragma warning disable 649
        [SerializeField] private Level level;
#pragma warning restore 649
    }
}
