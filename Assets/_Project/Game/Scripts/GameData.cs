using _Project.Levels._Shared.Scripts;
using UnityEngine;

namespace _Project.Game.Scripts
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "Game/Data")]
    public class GameData : ScriptableObject
    {
        #region Properties

        public short MaxLevelAchieved
        {
            get => maxLevelAchieved;
            set => maxLevelAchieved = value;
        }

        public Level[] Levels => levels;

        #endregion

#pragma warning disable 649
        [Min(1), SerializeField] private short maxLevelAchieved;

        [Space] [SerializeField] private Level[] levels;
#pragma warning restore 649
    }
}
