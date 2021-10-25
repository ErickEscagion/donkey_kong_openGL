using UnityEngine;

namespace Project.Core.Scripts
{
    [ExecuteAlways]
    internal class GLDebug : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _transform = transform;

        private void OnRenderObject()
        {
            GL.PushMatrix();
            material.SetPass(0);
            GL.Begin(GL.QUADS);
            GL.Color(debugColor);

            foreach (var point in points)
            {
                GL.Vertex(point.position);
            }

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private Transform _transform;

#pragma warning disable 649
        [SerializeField] private Color debugColor;

        [Space, SerializeField] private Material material;
        [SerializeField] private Transform[] points;
#pragma warning restore 649
    }
}
