using UnityEngine;
using UnityEngine.Events;

namespace Project.Core.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class OpenGLCamera : MonoBehaviour
    {
        #region Events

        public static event UnityAction onDraw;

        #endregion

        #region Lifecycle

        private void OnPostRender() => onDraw?.Invoke();

        #endregion
    }
}
