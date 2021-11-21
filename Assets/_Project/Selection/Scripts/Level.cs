using _Project.Navigation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LevelAsset = _Project.Levels._Shared.Scripts.Level;

namespace _Project.Selection.Scripts
{
    [RequireComponent(typeof(Button))]
    internal class Level : MonoBehaviour
    {
        #region Lifecycle

        private void Awake()
        {
            _button = GetComponent<Button>();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        #endregion

        private void OnClick() => NavigationController.Push(_level.SceneName, LoadSceneMode.Single);

        public void Initialize(LevelAsset level)
        {
            _level = level;

            _button.onClick.AddListener(OnClick);
            _textMesh.text = _level.Name ?? string.Empty;
        }

        private LevelAsset _level;
        private Button _button;
        private TextMeshProUGUI _textMesh;
    }
}
