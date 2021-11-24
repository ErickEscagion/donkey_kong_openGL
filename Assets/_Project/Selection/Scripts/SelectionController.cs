using _Project.Levels._Shared.Scripts;
using _Project.Navigation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = _Project.Navigation.Scripts.Screen;

namespace _Project.Selection.Scripts
{
    public class SelectionController : Screen
    {
        public const string sceneName = "selection";

        #region Lifecycle

        protected override void Start()
        {
            base.Start();
            foreach (var level in levelsData.Levels)
            {
                var instance = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity, parentTransform);
                instance.Initialize(level);
            }
        }

        private void OnEnable() => returnButton.onClick.AddListener(OnReturnButtonClick);

        private void OnDisable() => returnButton.onClick.RemoveListener(OnReturnButtonClick);

        #endregion

        private void OnReturnButtonClick() => NavigationController.Navigate("menu");

#pragma warning disable 649
        [Header("Assets"), SerializeField] private LevelsData levelsData;
        [SerializeField] private Level levelPrefab;

        [Header("Scene"), SerializeField] private Transform parentTransform;
        [SerializeField] private Button returnButton;
#pragma warning restore 649
    }
}
