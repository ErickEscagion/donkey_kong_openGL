using UnityEngine;

namespace _Project.Levels.Level2.Scripts
{
    [ExecuteAlways]
    internal class Scenario : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField] private int lines = 6;
        [SerializeField] private int columns = 12;
        [SerializeField] private float p1 = 19.0f;
        [SerializeField] private float p2 = 33.5f;
        [SerializeField] private float pass = 4f;
        [SerializeField] private float trick = 0.2f;

        [Space, SerializeField] private Material material;
#pragma warning restore 649

        #region Lifecycle

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            DrawWalls();
            DrawStartEndFloor();
            DrawFloor();

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private void DrawFloor()
        {
            GL.Begin(GL.QUADS);

            //center
            for (var i = 0; i < lines; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (i % 2 == 0)
                    {
                        GL.Color(j % 2 == 0 ? Color.white : Color.gray);
                    }
                    else
                    {
                        GL.Color(j % 2 == 0 ? Color.gray : Color.white);
                    }

                    GL.Vertex3(p2 + pass + j * pass, p1 + i * pass, 0);
                    GL.Vertex3(p2 + j * pass, p1 + i * pass, 0);
                    GL.Vertex3(p2 + j * pass, p1 + pass + i * pass, 0);
                    GL.Vertex3(p2 + pass + j * pass, p1 + pass + i * pass, 0);
                }
            }
        }

        private void DrawStartEndFloor()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.green);

            //start
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 + pass, 0);
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 + pass, 0);

            //end
            GL.Vertex3(p2 + pass * columns + 3 * pass, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines / 2 + pass, 0);
            GL.Vertex3(p2 + pass * columns + 3 * pass, p1 + pass * lines / 2 + pass, 0);
        }

        private void DrawWalls()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.black);

            //1 - Esqueda
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 - 3 * pass - trick, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 - 3 * pass - trick, p1 + pass * lines / 2 + pass, 0);
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 + pass, 0);
            //2
            GL.Vertex3(p2 - 3 * pass - trick, p1 + pass * lines / 2 - pass - trick, 0);
            GL.Vertex3(p2 - 3 * pass - trick, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass - trick, 0);
            //3
            GL.Vertex3(p2, p1 - trick, 0);
            GL.Vertex3(p2 - trick, p1 - trick, 0);
            GL.Vertex3(p2 - trick, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass, 0);
            //4
            GL.Vertex3(p2 - trick, p1 - trick, 0);
            GL.Vertex3(p2 - trick, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1 - trick, 0);
            //5
            GL.Vertex3(p2 + pass * columns, p1 - trick, 0);
            GL.Vertex3(p2 + pass * columns + trick, p1 - trick, 0);
            GL.Vertex3(p2 + pass * columns + trick, p1 + (pass * lines / 2) - pass, 0);
            GL.Vertex3(p2 + pass * columns, p1 + (pass * lines / 2) - pass, 0);
            //6
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines / 2 - pass - trick, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + pass * lines / 2 - pass, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + pass * lines / 2 - pass - trick, 0);
            //7
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + pass * lines / 2 - pass - trick, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3 + trick, p1 + pass * lines / 2 - pass - trick, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3 + trick, p1 + pass * lines / 2 + pass + trick, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + pass * lines / 2 + pass + trick, 0);
            //8
            GL.Vertex3(p2 + pass * columns, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2 + pass * columns, p1 + (pass * lines / 2) + pass + trick, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + (pass * lines / 2) + pass + trick, 0);
            GL.Vertex3(p2 + pass * columns + pass * 3, p1 + (pass * lines / 2) + pass, 0);
            //9
            GL.Vertex3(p2 + pass * columns, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2 + pass * columns + trick, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2 + pass * columns + trick, p1 + (pass * lines) + trick, 0);
            GL.Vertex3(p2 + pass * columns, p1 + (pass * lines) + trick, 0);
            //10
            GL.Vertex3(p2 - trick, p1 + pass * lines, 0);
            GL.Vertex3(p2 - trick, p1 + pass * lines + trick, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + trick, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines, 0);
            //11
            GL.Vertex3(p2, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2 - trick, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2 - trick, p1 + (pass * lines) + trick, 0);
            GL.Vertex3(p2, p1 + (pass * lines) + trick, 0);
            //12
            GL.Vertex3(p2 - 3 * pass - trick, p1 + (pass * lines / 2) + pass + trick, 0);
            GL.Vertex3(p2 - 3 * pass - trick, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2, p1 + (pass * lines / 2) + pass, 0);
            GL.Vertex3(p2, p1 + (pass * lines / 2) + pass + trick, 0);
        }
    }
}
