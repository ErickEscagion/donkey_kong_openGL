using UnityEngine;

namespace _Project.FinishLine.Scripts
{
    public class FinishLine : MonoBehaviour
    {
        #region Properties

        public FinishLineData Data => finishLineData;

        #endregion

#pragma warning disable 649
        [SerializeField] private FinishLineData finishLineData;
#pragma warning restore 649
    }
}
