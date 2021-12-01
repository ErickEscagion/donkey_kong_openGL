using System.Collections.Generic;
using UnityEngine;

namespace _Project.Collider.Scripts
{
    public class RectCollider2s : MonoBehaviour
    {
        #region Properties

        public IEnumerable<RectCollider2> Data => colliders;

        #endregion

#pragma warning disable 649
        [SerializeField] private RectCollider2[] colliders;
#pragma warning restore 649
    }
}
