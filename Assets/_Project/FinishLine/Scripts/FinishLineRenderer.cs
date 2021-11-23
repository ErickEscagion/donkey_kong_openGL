using UnityEngine;

namespace _Project.FinishLine.Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(FinishLine))]
    public class FinishLineRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            Draw(finishLine.Data);

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private static void Draw(FinishLineData finishLineData)
        {
            GL.Begin(GL.QUADS);

            GL.Color(Color.black);

            GL.Vertex3(finishLineData.origin.x - finishLineData.width / 2,
                finishLineData.origin.y - finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x - finishLineData.width / 2,
                finishLineData.origin.y + finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x + finishLineData.width / 2,
                finishLineData.origin.y + finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x + finishLineData.width / 2,
                finishLineData.origin.y - finishLineData.height / 2, 0);

            GL.Color(finishLineData.color);

            GL.Vertex3(finishLineData.origin.x - finishLineData.width / 2,
                finishLineData.origin.y - finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x - finishLineData.width / 2,
                finishLineData.origin.y + finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x + finishLineData.width / 2,
                finishLineData.origin.y + finishLineData.height / 2, 0);
            GL.Vertex3(finishLineData.origin.x + finishLineData.width / 2,
                finishLineData.origin.y - finishLineData.height / 2, 0);
        }

#pragma warning disable 649
        [Space, SerializeField] private FinishLine finishLine;
        [SerializeField] private Material material;
#pragma warning restore 649
    }
}
