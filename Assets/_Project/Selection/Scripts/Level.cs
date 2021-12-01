using _Project.Levels._Shared.Scripts;
using _Project.Navigation.Scripts;
using DG.Tweening;
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
            if (_sequence != null && !_sequence.IsComplete())
            {
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();
            _sequence
                .Join(borderImage.DOColor(selectedColor, time))
                .Join(indexTextMesh.DOColor(selectedColor, time))
                .Join(nameTextMesh.DOColor(selectedColor, time));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_sequence != null && !_sequence.IsComplete())
            {
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();
            _sequence
                .Join(borderImage.DOColor(deselectedColor, time))
                .Join(indexTextMesh.DOColor(deselectedColor, time))
                .Join(nameTextMesh.DOColor(deselectedColor, time));
        }

        #endregion

        private void OnClick() => NavigationController.Push(_level.SceneName, LoadSceneMode.Single, LevelData.Training);

        public void Initialize(LevelAsset level)
        {
            _level = level;

            indexTextMesh.text = level.Index.ToString();
            nameTextMesh.text = level.Name;
            _button.onClick.AddListener(OnClick);
        }

        private Sequence _sequence;
        private LevelAsset _level;
        private Button _button;

#pragma warning disable 649
        [SerializeField] private float time = .5f;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color deselectedColor;

        [Header("Scene"), SerializeField] private Image borderImage;
        [SerializeField] private TextMeshProUGUI indexTextMesh;
        [SerializeField] private TextMeshProUGUI nameTextMesh;
#pragma warning restore 649
    }
}
