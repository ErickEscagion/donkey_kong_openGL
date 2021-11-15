using _Project.Levels.Level1.Scripts;
using _Project.LevelSelection.Scripts;
using _Project.Navigation.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Menu.Scripts
{
    public class MenuController : Navigation.Scripts.Screen
    {
        public const string sceneName = "menu";

        #region Lifecycle

        private void OnEnable()
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
            levelSelectionButton.onClick.AddListener(OnLevelSelectionButtonClick);
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveListener(OnPlayButtonClick);
            levelSelectionButton.onClick.RemoveListener(OnLevelSelectionButtonClick);
        }

        #endregion

        private static void OnPlayButtonClick() =>
            NavigationController.Push(Level1Controller.sceneName, LoadSceneMode.Single);

        private static void OnLevelSelectionButtonClick() =>
            NavigationController.Push(LevelSelectionController.sceneName, LoadSceneMode.Single);

#pragma warning disable 649
        [Header("Scene")] [SerializeField] private Button playButton;
        [SerializeField] private Button levelSelectionButton;
#pragma warning restore 649
    }
}
