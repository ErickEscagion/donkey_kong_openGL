using _Project.Levels._Shared.Scripts;
using TMPro;
using UnityEngine;
using Screen = _Project.Navigation.Scripts.Screen;

namespace _Project.GameOver.Scripts
{
    public class GameOverController : Screen
    {
        #region Lifecycle

        protected override void Start()
        {
            base.Start();

            totalTimeTextMesh.text = levelsData.Time.ToString();
            totalDeathsTextMesh.text = levelsData.Deaths.ToString();
        }

        #endregion

#pragma warning disable 649
        [Header("Assets"), SerializeField] private LevelsData levelsData;

        [Header("Scene"), SerializeField] private TextMeshProUGUI totalTimeTextMesh;
        [SerializeField] private TextMeshProUGUI totalDeathsTextMesh;
#pragma warning restore 649
    }
}
