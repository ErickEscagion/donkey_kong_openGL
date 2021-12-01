using System.Collections.Generic;
using UnityEngine;

namespace _Project.Coins.Scripts
{
    public class Coins : MonoBehaviour
    {
        #region Lifecycle

        public IEnumerable<Coin> Data => coins;

        #endregion

#pragma warning disable 649
        [SerializeField] private Coin[] coins;
#pragma warning restore 649
    }
}
