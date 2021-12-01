using UnityEngine;

namespace _Project.Levels._Shared.Scripts
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "Game/Data")]
    public class LevelsData : ScriptableObject
    {
        #region Properties

        public int Deaths
        {
            get => deaths;
            set => deaths = value;
        }

        public int Time
        {
            get => time;
            set => time = value;
        }

        public short MaxLevelAchieved
        {
            get => maxLevelAchieved;
            set => maxLevelAchieved = value;
        }

        public Level[] Levels => levels;

        #endregion

#pragma warning disable 649
        [Min(1), SerializeField] private short maxLevelAchieved;
        [SerializeField] private int deaths;
        [SerializeField] private int time;

        [Space, SerializeField] private Level[] levels;
#pragma warning restore 649
    }
}
