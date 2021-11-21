using System;
using System.Collections;
using _Project.Navigation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Levels._Shared.Scripts
{
    internal class UI_LevelController : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _timeWaitForSeconds = new WaitForSeconds(1f);

        private void Start()
        {
            indexTextMesh.text = level.Index.ToString();
            deathsTextMesh.text = string.Concat(Deaths, level.Deaths.ToString());

            StartCoroutine(TimeCoroutine());
        }

        private void OnEnable() => button.onClick.AddListener(OnMenuButtonClick);

        private void OnDisable() => button.onClick.RemoveListener(OnMenuButtonClick);

        #endregion

        private static void OnMenuButtonClick() => NavigationController.Navigate("menu");

        #region Coroutines

        private IEnumerator TimeCoroutine()
        {
            while (true)
            {
                yield return _timeWaitForSeconds;
                _time++;
                timeTextMesh.text = _time.ToString();
            }
        }

        #endregion

        private const string Deaths = "DEATHS: ";

        private int _time;

        private WaitForSeconds _timeWaitForSeconds;

#pragma warning disable 649
        [Header("Assets"), SerializeField] private Level level;

        [Header("Scene"), SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI indexTextMesh;
        [SerializeField] private TextMeshProUGUI deathsTextMesh;
        [SerializeField] private TextMeshProUGUI timeTextMesh;
#pragma warning restore 649
    }
}
