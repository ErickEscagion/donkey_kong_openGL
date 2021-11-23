using System;
using _Project.Levels._Shared.Scripts;
using _Project.Navigation.Scripts;
using UnityEngine.SceneManagement;

namespace _Project.Levels.Level1.Scripts
{
    public class Level1Controller : LevelController
    {
        public const string sceneName = "level1";

        #region Properties

        protected override string SceneName => sceneName;

        protected override void OnLevelStateChange(LevelState state)
        {
            switch (state)
            {
                case LevelState.Defeat:
                    levelsData.Deaths++;
                    NavigationController.Navigate(SceneName, LoadSceneMode.Single);
                    break;
                case LevelState.Victory:
                    NavigationController.Navigate(levelsData.Levels[level.Index].SceneName, LoadSceneMode.Single);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        #endregion
    }
}
