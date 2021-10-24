using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Project.Core.Scripts
{
    public abstract class OpenGlObject : MonoBehaviour
    {
        #region Properties

        protected Vector3 Position => _transform.position;

        #endregion

        #region Lifecycle

        private void Awake() => _transform = transform;

        private void OnEnable() => OpenGLCamera.onDraw += OnGLDraw;

        private void OnDisable() => OpenGLCamera.onDraw -= OnGLDraw;

        #endregion

        protected abstract void OnGLDraw();

        private Transform _transform;
    }
}
