using _Project.Game.Scripts;
using _Project.Navigation.Scripts;
using _Project.Selection.Scripts;
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

        private  void OnPlayButtonClick() =>
            NavigationController.Push(gameData.Levels[gameData.MaxLevelAchieved - 1].name, LoadSceneMode.Single);

        private static void OnLevelSelectionButtonClick() =>
            NavigationController.Push(SelectionController.sceneName, LoadSceneMode.Single);

#pragma warning disable 649
        [Header("Assets"), SerializeField] private GameData gameData;

        [Header("Scene"),SerializeField] private Button playButton;
        [SerializeField] private Button levelSelectionButton;
#pragma warning restore 649
    }
}
