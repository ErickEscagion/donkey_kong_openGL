using _Project.Game.Scripts;
using UnityEngine;
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
            foreach (var level in gameData.Levels)
            {
                var instance = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity, parentTransform);
                instance.Initialize(level);
            }
        }

        #endregion

#pragma warning disable 649
        [Header("Assets"), SerializeField] private GameData gameData;
        [SerializeField] private Level levelPrefab;

        [Header("Scene"), SerializeField] private Transform parentTransform;
#pragma warning restore 649
    }
}
