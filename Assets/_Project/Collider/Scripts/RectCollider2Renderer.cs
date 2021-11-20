using UnityEngine;

namespace _Project.Collider.Scripts
{
    [ExecuteAlways]
    public class RectCollider2Renderer : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _colliders = GetComponent<RectCollider2s>();

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            foreach (var enemy in _colliders.Data)
            {
                Draw(enemy);
            }

            GL.End();
            GL.PopMatrix();
        }

        private static void Draw(RectCollider2 collider)
        {
            GL.Begin(GL.QUADS);

            GL.Color(Color.black);

            GL.Vertex3(collider.origin.x - collider.width / 2, collider.origin.y - collider.height / 2, 0);
            GL.Vertex3(collider.origin.x - collider.width / 2, collider.origin.y + collider.height / 2, 0);
            GL.Vertex3(collider.origin.x + collider.width / 2, collider.origin.y + collider.height / 2, 0);
            GL.Vertex3(collider.origin.x + collider.width / 2, collider.origin.y - collider.height / 2, 0);

            GL.Color(collider.color);

            GL.Vertex3(collider.origin.x - collider.width / 2, collider.origin.y - collider.height / 2, 0);
            GL.Vertex3(collider.origin.x - collider.width / 2, collider.origin.y + collider.height / 2, 0);
            GL.Vertex3(collider.origin.x + collider.width / 2, collider.origin.y + collider.height / 2, 0);
            GL.Vertex3(collider.origin.x + collider.width / 2, collider.origin.y - collider.height / 2, 0);
        }

        #endregion

        private RectCollider2s _colliders;

#pragma warning disable 649
        [SerializeField] private Material material;
#pragma warning restore 649
    }
}
