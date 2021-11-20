using System;
using _Project._Core.Scripts;
using _Project.Data.Scripts;
using _Project.Navigation.Scripts;

namespace _Project.Levels.Level2.Scripts
{
    public class Level2Controller : Screen
    {
        public const string sceneName = "level2";

        #region Lifecycle

        private void OnEnable() => DataEvent<LevelState>.call += OnLevelStateChange;

        private void OnDisable() => DataEvent<LevelState>.call -= OnLevelStateChange;

        #endregion

        private static void OnLevelStateChange(LevelState state)
        {
            switch (state)
            {
                case LevelState.Defeat:
                    NavigationController.Navigate(sceneName);
                    break;
                case LevelState.Victory:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
