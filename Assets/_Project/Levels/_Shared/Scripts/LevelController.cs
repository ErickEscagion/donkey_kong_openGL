using System;
using _Project.Data.Scripts;
using _Project.Navigation.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Levels._Shared.Scripts
{
    public abstract class LevelController : Screen<LevelData>
    {
        #region Properties

        protected abstract string SceneName { get; }

        #endregion

        #region Lifecycle

        private void OnEnable() => DataEvent<LevelState>.call += OnLevelStateChange;

        private void OnDisable() => DataEvent<LevelState>.call -= OnLevelStateChange;

        #endregion

        protected virtual void OnLevelStateChange(LevelState state)
        {
            switch (state)
            {
                case LevelState.Defeat:
                    levelsData.Deaths++;
                    NavigationController.Navigate(SceneName, LoadSceneMode.Single);
                    break;
                case LevelState.Victory:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

#pragma warning disable 649
        [SerializeField] protected Level level;
        [SerializeField] protected LevelsData levelsData;
#pragma warning restore 649
    }
}
