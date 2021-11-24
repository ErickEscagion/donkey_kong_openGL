using System;
using _Project.Levels._Shared.Scripts;
using _Project.Navigation.Scripts;
using UnityEngine.SceneManagement;

namespace _Project.Levels.Level2.Scripts
{
    public class Level2Controller : LevelController
    {
        public const string sceneName = "level2";

        #region Properties

        protected override string SceneName => sceneName;

        #endregion

        protected override void Initialize(LevelData value) => _data = value;

        protected override void OnLevelStateChange(LevelState state)
        {
            switch (state)
            {
                case LevelState.Defeat:
                    levelsData.Deaths++;
                    NavigationController.Navigate(SceneName, LoadSceneMode.Single);
                    break;
                case LevelState.Victory:
                    NavigationController.Navigate(
                        _data.Equals(LevelData.Normal) ? levelsData.Levels[level.Index].SceneName : "selection",
                        LoadSceneMode.Single);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private LevelData _data;
    }
}
