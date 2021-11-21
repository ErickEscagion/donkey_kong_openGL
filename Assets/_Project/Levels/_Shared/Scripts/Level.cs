using UnityEngine;

namespace _Project.Levels._Shared.Scripts
{
    [CreateAssetMenu(menuName = "Game/Level", fileName = "New Level")]
    public class Level : ScriptableObject
    {
        #region Properties

        public int Index
        {
            get => index;
            set => index = value;
        }

        public int Deaths
        {
            get => deaths;
            set => deaths = value;
        }

        public string Name => name;

        public string SceneName => sceneName;

        #endregion

#pragma warning disable 649
        [SerializeField] private int index;
        [SerializeField] private int deaths;
        [SerializeField] private new string name;
        [SerializeField] private string sceneName;
#pragma warning restore 649
    }
}
