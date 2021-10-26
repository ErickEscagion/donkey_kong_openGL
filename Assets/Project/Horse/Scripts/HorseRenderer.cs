using UnityEngine;

namespace Project.Horse.Scripts
{
    [ExecuteAlways]
    public class HorseRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _transform = transform;

        private void OnRenderObject()
        {
            GL.PushMatrix();
            material.SetPass(0);
            GL.Begin(GL.QUADS);

            DrawHorseV1(
                _transform.position,
                _transform.rotation,
                _transform.localScale);

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private void DrawHorseV1(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            DrawHorsehair(translation, rotation, scale);
            DrawFrontRightPaw(translation, rotation, scale);
            DrawBackRightPaw(translation, rotation, scale);
            DrawBody(translation, rotation, scale);
            DrawNeck(translation, rotation, scale);
            DrawHead(translation, rotation, scale);
            DrawFrontLeftPaw(translation, rotation, scale);
            DrawBackLeftPaw(translation, rotation, scale);
            DrawTail(translation, rotation, scale);
        }

        private void DrawBody(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(bodyColor);

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, -0.5f)));
        }

        private void DrawNeck(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(bodyColor);

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 0.5f)));
        }

        private void DrawHead(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(bodyColor);

            // Snout
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.6f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1.4f, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1.4f, 1.6f)));

            // Forehead
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 1.25f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 1.8f)));

            // Left Ear
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 2.1f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 2.1f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 1.8f)));

            GL.Color(shadowBodyColor);

            // Right Ear
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.85f, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.85f, 2.1f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 2.1f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, 1.8f)));

            GL.Color(eyeColor);

            // Eye
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 1.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 1.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, 1.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, 1.5f)));
        }

        private void DrawFrontLeftPaw(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(bodyColor);

            // Paw
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.55f, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.55f, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, -1.3f)));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.55f, -1.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.55f, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.75f, -1.5f)));
        }

        private void DrawFrontRightPaw(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(shadowBodyColor);

            // Paw
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.8f, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.8f, -0.4f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, -0.4f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, -1.2f)));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.8f, -1.4f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.8f, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(1, -1.4f)));
        }

        private void DrawBackLeftPaw(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(bodyColor);

            // Paw
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.8f, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.8f, -0.85f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.85f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -1.3f)));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -1.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.2f, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -1.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1, -1.5f)));
        }

        private void DrawBackRightPaw(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(shadowBodyColor);

            // Paw
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.5f, -0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.5f, -0.85f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -0.85f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -0.75f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -0.75f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -1.2f)));

            GL.Color(hullColor);

            // Hull
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -1.4f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.9f, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -1.2f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.7f, -1.4f)));
        }

        private void DrawTail(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(horsehairColor);

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.5f, 0.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.5f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1f, 0.3f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.6f, 0.15f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.6f, 0.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.15f, 0.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.15f, 0.15f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.75f, 0.3f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.75f, 0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.45f, 0.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.45f, 0.3f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.90f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.90f, 0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.55f, 0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.55f, 0.5f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.35f, 0.6f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.35f, 0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.85f, 0.85f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-1.80f, 0.6f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.45f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.45f, 0.75f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.25f, 0.75f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.25f, 0.5f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.5f, 0.4f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.5f, 0.6f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.3f, 0.6f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-2.3f, 0.4f)));
        }

        private void DrawHorsehair(Vector3 translation, Quaternion rotation, Vector3 scale)
        {
            GL.Color(horsehairColor);

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.6f, 1.95f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.85f, 1.95f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.85f, 1.8f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 1.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.8f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.65f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.26f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.26f, 1.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 1.65f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.4f, 0.5f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 1.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.26f, 1.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0.26f, 0.5f)));

            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.26f, 0.5f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(-0.26f, 0.62f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 0.62f)));
            GL.Vertex(Matrix4x4.TRS(translation, rotation, scale).MultiplyPoint3x4(new Vector2(0, 0.5f)));
        }

        private Transform _transform;

#pragma warning disable 649
        [SerializeField] private Color bodyColor;
        [SerializeField] private Color eyeColor;
        [SerializeField] private Color shadowBodyColor;
        [SerializeField] private Color horsehairColor;
        [SerializeField] private Color hullColor;

        [Space, SerializeField] private Material material;
#pragma warning restore 649
    }
}
