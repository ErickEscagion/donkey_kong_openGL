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
            deathsTextMesh.text = FormatDeaths(level.Deaths);

            StartCoroutine(TimeCoroutine());
        }

        private void OnEnable() => button.onClick.AddListener(OnMenuButtonClick);

        private void OnDisable() => button.onClick.RemoveListener(OnMenuButtonClick);

        #endregion

        private static void OnMenuButtonClick() => NavigationController.Navigate("menu");

        private static string FormatDeaths(int deaths) => string.Concat(Deaths, deaths);

        private static string FormatTime(int time)
        {
            var hours = time / 3600;
            var minutes = (time - hours * 3600) / 60;
            var seconds = time - hours * 3600 - minutes * 60;

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        #region Coroutines

        private IEnumerator TimeCoroutine()
        {
            while (true)
            {
                yield return _timeWaitForSeconds;
                _time++;
                timeTextMesh.text = FormatTime(_time);
            }
        }

        #endregion

        private const string Deaths = "DEATHS: ";

        private int _time;

        private WaitForSeconds _timeWaitForSeconds;

#pragma warning disable 649
        [Header("Assets"), SerializeField] private Level level;

        [Header("Scene"), SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI deathsTextMesh;
        [SerializeField] private TextMeshProUGUI timeTextMesh;
#pragma warning restore 649
    }
}
