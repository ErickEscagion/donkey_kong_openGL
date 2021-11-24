using _Project.Navigation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LevelAsset = _Project.Levels._Shared.Scripts.Level;

namespace _Project.Selection.Scripts
{
    [RequireComponent(typeof(Button))]
    internal class Level : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Lifecycle

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        #endregion

        #region UI Events

        public void OnPointerEnter(PointerEventData eventData)
        {
            borderImage.color = selectedColor;
            indexTextMesh.color = selectedColor;
            nameTextMesh.color = selectedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            borderImage.color = deselectedColor;
            indexTextMesh.color = deselectedColor;
            nameTextMesh.color = deselectedColor;
        }

        #endregion

        private void OnClick() => NavigationController.Push(_level.SceneName, LoadSceneMode.Single);

        public void Initialize(LevelAsset level)
        {
            _level = level;

            indexTextMesh.text = level.Index.ToString();
            nameTextMesh.text = level.Name;
            _button.onClick.AddListener(OnClick);
        }

        private LevelAsset _level;
        private Button _button;

#pragma warning disable 649
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color deselectedColor;

        [Header("Scene"),SerializeField] private Image borderImage;
        [SerializeField] private TextMeshProUGUI indexTextMesh;
        [SerializeField] private TextMeshProUGUI nameTextMesh;
#pragma warning restore 649
    }
}
