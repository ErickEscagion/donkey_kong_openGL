using UnityEngine;

namespace _Project.Levels.Level3.Scripts
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
        [SerializeField] private float size = 0.2f;

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
                    GL.Vertex3((p2 + pass) + j * pass, p1 + pass + i * pass, 0);
                }
            }
        }

        private void DrawStartEndFloor()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.green);

            //start
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 + pass + pass / 2, 0);
            //end
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + 3 * pass, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines + 3 * pass, 0);
        }

        private void DrawWalls()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.black);

            //1 - Esqueda
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass, p1 + pass * lines / 2 + pass + pass / 2, 0);
            //2
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 - pass - size - pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass - size - pass / 2, 0);
            //3
            GL.Vertex3(p2, p1 - size, 0);
            GL.Vertex3(p2 - size, p1 - size, 0);
            GL.Vertex3(p2 - size, p1 + pass * lines / 2 - pass - pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 - pass - pass / 2, 0);
            //4
            GL.Vertex3(p2 - size, p1 - size, 0);
            GL.Vertex3(p2 - size, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1 - size, 0);
            //5
            GL.Vertex3(p2 + pass * columns, p1 - size, 0);
            GL.Vertex3(p2 + pass * columns + size, p1 - size, 0);
            GL.Vertex3(p2 + pass * columns + size, p1 + pass * lines + 3 * pass + size, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + 3 * pass + size, 0);

            //6
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines + 3 * pass, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines + 3 * pass + size, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + 3 * pass + size, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + 3 * pass, 0);

            //7
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass - size, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass - size, p1 + pass * lines + 3 * pass + size, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines + 3 * pass + size, 0);

            //8
            GL.Vertex3(p2 - size, p1 + pass * lines, 0);
            GL.Vertex3(p2 - size, p1 + pass * lines + size, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines + size, 0);
            GL.Vertex3(p2 + pass * columns - 3 * pass, p1 + pass * lines, 0);
            //9
            GL.Vertex3(p2, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2 - size, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2 - size, p1 + pass * lines + size, 0);
            GL.Vertex3(p2, p1 + pass * lines + size, 0);
            //10
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 + pass + size + pass / 2, 0);
            GL.Vertex3(p2 - 3 * pass - size, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 + pass + pass / 2, 0);
            GL.Vertex3(p2, p1 + pass * lines / 2 + pass + size + pass / 2, 0);
        }
    }
}
