using System.Collections.Generic;
using UnityEngine;

namespace _Project._Core.Scripts
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

        public IEnumerable<string> Levels => levels;

        #endregion

#pragma warning disable 649
        [SerializeField] private short maxLevelAchieved;

        [Space] [SerializeField] private string[] levels;
#pragma warning restore 649
    }
}
