using UnityEngine;

namespace _Project.Levels.Level1.Scripts
{
    [ExecuteAlways]
    internal class Scenario : MonoBehaviour
    {
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

            //start
            GL.Color(Color.red);
            GL.Vertex3((p2 - pass), (p1 - pass), 0);
            GL.Vertex3(p2, (p1 - pass), 0);
            GL.Vertex3(p2, p1, 0);
            GL.Vertex3((p2 - pass), p1, 0);
            GL.Color(Color.blue);
            GL.Vertex3(p2, (p1 - pass), 0);
            GL.Vertex3((p2 + pass), (p1 - pass), 0);
            GL.Vertex3((p2 + pass), p1, 0);
            GL.Vertex3(p2, p1, 0);

            //end
            GL.Color(Color.blue);
            GL.Vertex3(p2 + pass * columns + pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 + pass * columns + pass, p1 + pass * lines + pass, 0);
            GL.Color(Color.red);
            GL.Vertex3(p2 + (pass * columns), p1 + (pass * lines), 0);
            GL.Vertex3(p2 + (pass * columns) - pass, p1 + (pass * lines), 0);
            GL.Vertex3(p2 + (pass * columns) - pass, p1 + (pass * lines) + pass, 0);
            GL.Vertex3(p2 + (pass * columns), p1 + (pass * lines) + pass, 0);

            for (var i = 0; i < lines; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (i % 2 == 0)
                    {
                        GL.Color(j % 2 == 0 ? Color.red : Color.blue);
                    }
                    else
                    {
                        GL.Color(j % 2 == 0 ? Color.blue : Color.red);
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
            GL.Vertex3((p2 - 4 * pass), p1 - pass, 0);
            GL.Vertex3((p2 - pass), p1 - pass, 0);
            GL.Vertex3((p2 - pass), p1 + (pass * lines) + pass, 0);
            GL.Vertex3((p2 - 4 * pass), p1 + (pass * lines) + pass, 0);

            //end
            GL.Vertex3(((p2 + pass * columns) + 4 * pass), p1 - pass, 0);
            GL.Vertex3((p2 + pass * columns + pass), p1 - pass, 0);
            GL.Vertex3((p2 + pass * columns + pass), p1 + (pass * lines) + pass, 0);
            GL.Vertex3(((p2 + pass * columns) + 4 * pass), p1 + (pass * lines) + pass, 0);
        }

        private void DrawWalls()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.black);

            const float size = 0.7f;

            //1 - Left
            GL.Vertex3(p2 - 4 * pass, p1 - pass, 0);
            GL.Vertex3(p2 - 4 * pass - size, p1 - pass, 0);
            GL.Vertex3(p2 - 4 * pass - size, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 - 4 * pass, p1 + pass * lines + pass, 0);
            //2
            GL.Vertex3(p2 - 4 * pass - size, p1 - pass - size, 0);
            GL.Vertex3(p2 - 4 * pass - size, p1 - pass, 0);
            GL.Vertex3(p2 + pass, p1 - pass, 0);
            GL.Vertex3(p2 + pass, p1 - pass - size, 0);
            //3
            GL.Vertex3(p2 + pass, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass + size, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass + size, p1, 0);
            GL.Vertex3(p2 + pass, p1, 0);
            //4
            GL.Vertex3(p2 + pass, p1 - size, 0);
            GL.Vertex3(p2 + pass, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1, 0);
            GL.Vertex3(p2 + pass * columns, p1 - size, 0);
            //5
            GL.Vertex3(p2 + pass * columns, p1 - size, 0);
            GL.Vertex3(p2 + pass * columns + size, p1 - size, 0);
            GL.Vertex3(p2 + pass * columns + size, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines, 0);
            //6
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines - size, 0);
            GL.Vertex3(p2 + pass * columns, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns + pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns + pass, p1 + pass * lines - size, 0);
            //7
            GL.Vertex3(p2 + pass * columns + pass - size, p1 - pass, 0);
            GL.Vertex3(p2 + pass * columns + pass, p1 - pass, 0);
            GL.Vertex3(p2 + pass * columns + pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns + pass - size, p1 + pass * lines, 0);
            //8
            GL.Vertex3(p2 + pass * columns + pass - size, p1 - pass, 0);
            GL.Vertex3(p2 + pass * columns + pass - size, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 - pass, 0);
            //9
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4 + size, p1 - pass - size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4 + size, p1 + pass * lines + pass + size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 + pass * lines + pass + size, 0);
            //10
            GL.Vertex3(p2 + pass * columns - pass - size, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 + pass * columns - pass - size, p1 + pass * lines + pass + size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 + pass * lines + pass + size, 0);
            GL.Vertex3(p2 + pass * columns + pass * 4, p1 + pass * lines + pass, 0);
            //11
            GL.Vertex3(p2 + pass * columns - pass - size, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns - pass, p1 + pass * lines, 0);
            GL.Vertex3(p2 + pass * columns - pass, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 + pass * columns - pass - size, p1 + pass * lines + pass, 0);
            //12
            GL.Vertex3(p2 - size, p1 + pass * lines, 0);
            GL.Vertex3(p2 - size, p1 + pass * lines + size, 0);
            GL.Vertex3(p2 + pass * columns - pass, p1 + pass * lines + size, 0);
            GL.Vertex3(p2 + pass * columns - pass, p1 + pass * lines, 0);
            //13
            GL.Vertex3(p2, p1, 0);
            GL.Vertex3(p2 - size, p1, 0);
            GL.Vertex3(p2 - size, p1 + lines * pass, 0);
            GL.Vertex3(p2, p1 + lines * pass, 0);
            //14
            GL.Vertex3(p2 - pass, p1 + size, 0);
            GL.Vertex3(p2 - pass, p1, 0);
            GL.Vertex3(p2, p1, 0);
            GL.Vertex3(p2, p1 + size, 0);
            //15
            GL.Vertex3(p2 - pass, p1, 0);
            GL.Vertex3(p2 - pass + size, p1, 0);
            GL.Vertex3(p2 - pass + size, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 - pass, p1 + pass * lines + pass, 0);
            //16
            GL.Vertex3(p2 - 4 * pass - size, p1 + pass * lines + pass, 0);
            GL.Vertex3(p2 - 4 * pass - size, p1 + pass * lines + pass + size, 0);
            GL.Vertex3(p2 - pass + size, p1 + pass * lines + pass + size, 0);
            GL.Vertex3(p2 - pass + size, p1 + pass * lines + pass, 0);
        }

#pragma warning disable 649
        [SerializeField] private int lines = 4;
        [SerializeField] private int columns = 11;
        [SerializeField] private float p1 = 19.0f;
        [SerializeField] private float p2 = 33.5f;
        [SerializeField] private float pass = 4f;

        [Space, SerializeField] private Material material;
#pragma warning restore 649
    }
}
