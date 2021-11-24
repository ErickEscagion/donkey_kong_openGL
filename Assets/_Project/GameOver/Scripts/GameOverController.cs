using System;
using _Project.Levels._Shared.Scripts;
using _Project.Navigation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = _Project.Navigation.Scripts.Screen;

namespace _Project.GameOver.Scripts
{
    public class GameOverController : Screen
    {
        #region Lifecycle

        protected override void Start()
        {
            base.Start();

            titleTextMesh.text = FormatText(levelsData.Deaths, levelsData.Time);
        }

        private void OnEnable()
        {
            restartButton.onClick.AddListener(OnRestartButtonClick);
            returnToMenuButton.onClick.AddListener(OnReturnButtonClick);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(OnRestartButtonClick);
            returnToMenuButton.onClick.RemoveListener(OnReturnButtonClick);
        }

        #endregion

        private static string FormatText(int deaths, int time)
        {
            var hours = time / 3600;
            var minutes = (time - hours * 3600) / 60;
            var seconds = time - hours * 3600 - minutes * 60;

            return $"you finish with {deaths} deaths in {hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        private void OnRestartButtonClick() =>
            NavigationController.Navigate(levelsData.Levels[0].SceneName, LevelData.Normal);

        private static void OnReturnButtonClick() => NavigationController.Navigate("menu");

#pragma warning disable 649
        [Header("Assets"), SerializeField] private LevelsData levelsData;

        [Header("Scene"), SerializeField] private TextMeshProUGUI titleTextMesh;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button returnToMenuButton;
#pragma warning restore 649
    }
}
