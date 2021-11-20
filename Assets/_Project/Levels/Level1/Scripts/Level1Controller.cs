using System;
using _Project._Core.Scripts;
using _Project.Data.Scripts;
using _Project.Navigation.Scripts;
using Screen = _Project.Navigation.Scripts.Screen;

namespace _Project.Levels.Level1.Scripts
{
    public class Level1Controller : Screen
    {
        public const string sceneName = "level1";

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
