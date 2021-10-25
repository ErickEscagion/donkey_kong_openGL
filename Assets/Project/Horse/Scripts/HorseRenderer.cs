using UnityEngine;

namespace Project.Horse.Scripts
{
    [ExecuteInEditMode]
    public class HorseRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _transform = transform;

        private void OnRenderObject()
        {
            GL.PushMatrix();
            material.SetPass(0);
            GL.Begin(GL.QUADS);

            var origin = _transform.position;

            DrawFrontRightPaw(origin);
            DrawBackRightPaw(origin);
            DrawBody(origin);
            DrawNeck(origin);
            DrawHead(origin);
            DrawFrontLeftPaw(origin);
            DrawBackLeftPaw(origin);
            DrawTail(origin);

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private void DrawBody(Vector2 origin)
        {
            GL.Color(bodyColor);

            GL.Vertex(origin + new Vector2(-1, -0.5f));
            GL.Vertex(origin + new Vector2(-1, 0.5f));
            GL.Vertex(origin + new Vector2(1, 0.5f));
            GL.Vertex(origin + new Vector2(1, -0.5f));
        }

        private void DrawNeck(Vector2 origin)
        {
            GL.Color(bodyColor);

            GL.Vertex(origin + new Vector2(0.4f, 0.5f));
            GL.Vertex(origin + new Vector2(0.4f, 1.25f));
            GL.Vertex(origin + new Vector2(1, 1.25f));
            GL.Vertex(origin + new Vector2(1, 0.5f));
        }

        private void DrawHead(Vector2 origin)
        {
            GL.Color(bodyColor);

            // Snout
            GL.Vertex(origin + new Vector2(0.4f, 1.6f));
            GL.Vertex(origin + new Vector2(0.4f, 1.25f));
            GL.Vertex(origin + new Vector2(1.4f, 1.25f));
            GL.Vertex(origin + new Vector2(1.4f, 1.6f));

            // Forehead
            GL.Vertex(origin + new Vector2(0.4f, 1.8f));
            GL.Vertex(origin + new Vector2(0.4f, 1.25f));
            GL.Vertex(origin + new Vector2(1, 1.25f));
            GL.Vertex(origin + new Vector2(1, 1.8f));

            // Left Ear
            GL.Vertex(origin + new Vector2(0.4f, 1.8f));
            GL.Vertex(origin + new Vector2(0.4f, 2.1f));
            GL.Vertex(origin + new Vector2(0.6f, 2.1f));
            GL.Vertex(origin + new Vector2(0.6f, 1.8f));

            GL.Color(shadowBodyColor);

            // Right Ear
            GL.Vertex(origin + new Vector2(0.85f, 1.8f));
            GL.Vertex(origin + new Vector2(0.85f, 2.1f));
            GL.Vertex(origin + new Vector2(1, 2.1f));
            GL.Vertex(origin + new Vector2(1, 1.8f));

            GL.Color(horsehairColor);

            GL.Vertex(origin + new Vector2(0.6f, 1.5f));
            GL.Vertex(origin + new Vector2(0.6f, 1.65f));
            GL.Vertex(origin + new Vector2(0.75f, 1.65f));
            GL.Vertex(origin + new Vector2(0.75f, 1.5f));
        }

        private void DrawFrontLeftPaw(Vector2 origin)
        {
            GL.Color(bodyColor);

            // Paw
            GL.Vertex(origin + new Vector2(0.55f, -1.3f));
            GL.Vertex(origin + new Vector2(0.55f, -0.5f));
            GL.Vertex(origin + new Vector2(0.75f, -0.5f));
            GL.Vertex(origin + new Vector2(0.75f, -1.3f));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(origin + new Vector2(0.55f, -1.5f));
            GL.Vertex(origin + new Vector2(0.55f, -1.3f));
            GL.Vertex(origin + new Vector2(0.75f, -1.3f));
            GL.Vertex(origin + new Vector2(0.75f, -1.5f));
        }

        private void DrawFrontRightPaw(Vector2 origin)
        {
            GL.Color(shadowBodyColor);

            // Paw
            GL.Vertex(origin + new Vector2(0.8f, -1.2f));
            GL.Vertex(origin + new Vector2(0.8f, -0.4f));
            GL.Vertex(origin + new Vector2(1, -0.4f));
            GL.Vertex(origin + new Vector2(1, -1.2f));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(origin + new Vector2(0.8f, -1.4f));
            GL.Vertex(origin + new Vector2(0.8f, -1.2f));
            GL.Vertex(origin + new Vector2(1, -1.2f));
            GL.Vertex(origin + new Vector2(1, -1.4f));
        }

        private void DrawBackLeftPaw(Vector2 origin)
        {
            GL.Color(bodyColor);

            // Paw
            GL.Vertex(origin + new Vector2(-1, -0.85f));
            GL.Vertex(origin + new Vector2(-1, -0.5f));
            GL.Vertex(origin + new Vector2(-0.8f, -0.5f));
            GL.Vertex(origin + new Vector2(-0.8f, -0.85f));

            GL.Vertex(origin + new Vector2(-1.2f, -0.85f));
            GL.Vertex(origin + new Vector2(-1.2f, -0.65f));
            GL.Vertex(origin + new Vector2(-1, -0.65f));
            GL.Vertex(origin + new Vector2(-1, -0.85f));

            GL.Vertex(origin + new Vector2(-1.2f, -1.3f));
            GL.Vertex(origin + new Vector2(-1.2f, -0.85f));
            GL.Vertex(origin + new Vector2(-1, -0.85f));
            GL.Vertex(origin + new Vector2(-1, -1.3f));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(origin + new Vector2(-1.2f, -1.5f));
            GL.Vertex(origin + new Vector2(-1.2f, -1.3f));
            GL.Vertex(origin + new Vector2(-1, -1.3f));
            GL.Vertex(origin + new Vector2(-1, -1.5f));
        }

        private void DrawBackRightPaw(Vector2 origin)
        {
            GL.Color(shadowBodyColor);

            // Paw
            GL.Vertex(origin + new Vector2(-0.7f, -0.85f));
            GL.Vertex(origin + new Vector2(-0.7f, -0.5f));
            GL.Vertex(origin + new Vector2(-0.5f, -0.5f));
            GL.Vertex(origin + new Vector2(-0.5f, -0.85f));

            GL.Vertex(origin + new Vector2(-0.9f, -0.85f));
            GL.Vertex(origin + new Vector2(-0.9f, -0.65f));
            GL.Vertex(origin + new Vector2(-0.7f, -0.65f));
            GL.Vertex(origin + new Vector2(-0.7f, -0.85f));

            GL.Vertex(origin + new Vector2(-0.9f, -1.2f));
            GL.Vertex(origin + new Vector2(-0.9f, -0.75f));
            GL.Vertex(origin + new Vector2(-0.7f, -0.75f));
            GL.Vertex(origin + new Vector2(-0.7f, -1.2f));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(origin + new Vector2(-0.9f, -1.4f));
            GL.Vertex(origin + new Vector2(-0.9f, -1.2f));
            GL.Vertex(origin + new Vector2(-0.7f, -1.2f));
            GL.Vertex(origin + new Vector2(-0.7f, -1.4f));
        }

        private void DrawTail(Vector2 origin)
        {
            GL.Color(horsehairColor);

            GL.Vertex(origin + new Vector2(-1.5f, 0.3f));
            GL.Vertex(origin + new Vector2(-1.5f, 0.5f));
            GL.Vertex(origin + new Vector2(-1f, 0.5f));
            GL.Vertex(origin + new Vector2(-1f, 0.3f));

            GL.Vertex(origin + new Vector2(-1.6f, 0.15f));
            GL.Vertex(origin + new Vector2(-1.6f, 0.3f));
            GL.Vertex(origin + new Vector2(-1.15f, 0.3f));
            GL.Vertex(origin + new Vector2(-1.15f, 0.15f));

            GL.Vertex(origin + new Vector2(-1.75f, 0.3f));
            GL.Vertex(origin + new Vector2(-1.75f, 0.65f));
            GL.Vertex(origin + new Vector2(-1.45f, 0.65f));
            GL.Vertex(origin + new Vector2(-1.45f, 0.3f));

            GL.Vertex(origin + new Vector2(-1.90f, 0.5f));
            GL.Vertex(origin + new Vector2(-1.90f, 0.85f));
            GL.Vertex(origin + new Vector2(-1.55f, 0.85f));
            GL.Vertex(origin + new Vector2(-1.55f, 0.5f));

            GL.Vertex(origin + new Vector2(-2.35f, 0.6f));
            GL.Vertex(origin + new Vector2(-2.35f, 0.85f));
            GL.Vertex(origin + new Vector2(-1.85f, 0.85f));
            GL.Vertex(origin + new Vector2(-1.80f, 0.6f));

            GL.Vertex(origin + new Vector2(-2.45f, 0.5f));
            GL.Vertex(origin + new Vector2(-2.45f, 0.75f));
            GL.Vertex(origin + new Vector2(-2.25f, 0.75f));
            GL.Vertex(origin + new Vector2(-2.25f, 0.5f));

            GL.Vertex(origin + new Vector2(-2.5f, 0.4f));
            GL.Vertex(origin + new Vector2(-2.5f, 0.6f));
            GL.Vertex(origin + new Vector2(-2.3f, 0.6f));
            GL.Vertex(origin + new Vector2(-2.3f, 0.4f));
        }

        private Transform _transform;

#pragma warning disable 649
        [SerializeField] private Color bodyColor;
        [SerializeField] private Color shadowBodyColor;
        [SerializeField] private Color horsehairColor;
        [SerializeField] private Color hullColor;

        [Space, SerializeField] private Material material;
#pragma warning restore 649
    }
}
