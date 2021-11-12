using UnityEngine;

namespace _Project.Levels.Level1.Scripts
{
    [ExecuteAlways]
    internal class ScenarioRenderer : MonoBehaviour
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
            GL.Vertex3((origin.x - pass), (origin.y - pass), 0);
            GL.Vertex3(origin.x, (origin.y - pass), 0);
            GL.Vertex3(origin.x, origin.y, 0);
            GL.Vertex3((origin.x - pass), origin.y, 0);
            GL.Color(Color.blue);
            GL.Vertex3(origin.x, (origin.y - pass), 0);
            GL.Vertex3((origin.x + pass), (origin.y - pass), 0);
            GL.Vertex3((origin.x + pass), origin.y, 0);
            GL.Vertex3(origin.x, origin.y, 0);

            //end
            GL.Color(Color.blue);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y + pass * lines + pass, 0);
            GL.Color(Color.red);
            GL.Vertex3(origin.x + (pass * columns), origin.y + (pass * lines), 0);
            GL.Vertex3(origin.x + (pass * columns) - pass, origin.y + (pass * lines), 0);
            GL.Vertex3(origin.x + (pass * columns) - pass, origin.y + (pass * lines) + pass, 0);
            GL.Vertex3(origin.x + (pass * columns), origin.y + (pass * lines) + pass, 0);

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

                    GL.Vertex3(origin.x + pass + j * pass, origin.y + i * pass, 0);
                    GL.Vertex3(origin.x + j * pass, origin.y + i * pass, 0);
                    GL.Vertex3(origin.x + j * pass, origin.y + pass + i * pass, 0);
                    GL.Vertex3(origin.x + pass + j * pass, origin.y + pass + i * pass, 0);
                }
            }
        }

        private void DrawStartEndFloor()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.green);
            //start
            GL.Vertex3((origin.x - 4 * pass), origin.y - pass, 0);
            GL.Vertex3((origin.x - pass), origin.y - pass, 0);
            GL.Vertex3((origin.x - pass), origin.y + (pass * lines) + pass, 0);
            GL.Vertex3((origin.x - 4 * pass), origin.y + (pass * lines) + pass, 0);

            //end
            GL.Vertex3(((origin.x + pass * columns) + 4 * pass), origin.y - pass, 0);
            GL.Vertex3((origin.x + pass * columns + pass), origin.y - pass, 0);
            GL.Vertex3((origin.x + pass * columns + pass), origin.y + (pass * lines) + pass, 0);
            GL.Vertex3(((origin.x + pass * columns) + 4 * pass), origin.y + (pass * lines) + pass, 0);
        }

        private void DrawWalls()
        {
            GL.Begin(GL.QUADS);
            GL.Color(Color.black);

            //1 - Left
            GL.Vertex3(origin.x - 4 * pass, origin.y - pass, 0);
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y - pass, 0);
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x - 4 * pass, origin.y + pass * lines + pass, 0);
            //2
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y - pass, 0);
            GL.Vertex3(origin.x + pass, origin.y - pass, 0);
            GL.Vertex3(origin.x + pass, origin.y - pass - thick, 0);
            //3
            GL.Vertex3(origin.x + pass, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass + thick, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass + thick, origin.y, 0);
            GL.Vertex3(origin.x + pass, origin.y, 0);
            //4
            GL.Vertex3(origin.x + pass, origin.y - thick, 0);
            GL.Vertex3(origin.x + pass, origin.y, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y - thick, 0);
            //5
            GL.Vertex3(origin.x + pass * columns, origin.y - thick, 0);
            GL.Vertex3(origin.x + pass * columns + thick, origin.y - thick, 0);
            GL.Vertex3(origin.x + pass * columns + thick, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y + pass * lines, 0);
            //6
            GL.Vertex3(origin.x + pass * columns, origin.y + pass * lines - thick, 0);
            GL.Vertex3(origin.x + pass * columns, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y + pass * lines - thick, 0);
            //7
            GL.Vertex3(origin.x + pass * columns + pass - thick, origin.y - pass, 0);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y - pass, 0);
            GL.Vertex3(origin.x + pass * columns + pass, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns + pass - thick, origin.y + pass * lines, 0);
            //8
            GL.Vertex3(origin.x + pass * columns + pass - thick, origin.y - pass, 0);
            GL.Vertex3(origin.x + pass * columns + pass - thick, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y - pass, 0);
            //9
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4 + thick, origin.y - pass - thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4 + thick, origin.y + pass * lines + pass + thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y + pass * lines + pass + thick, 0);
            //10
            GL.Vertex3(origin.x + pass * columns - pass - thick, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x + pass * columns - pass - thick, origin.y + pass * lines + pass + thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y + pass * lines + pass + thick, 0);
            GL.Vertex3(origin.x + pass * columns + pass * 4, origin.y + pass * lines + pass, 0);
            //11
            GL.Vertex3(origin.x + pass * columns - pass - thick, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns - pass, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x + pass * columns - pass, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x + pass * columns - pass - thick, origin.y + pass * lines + pass, 0);
            //12
            GL.Vertex3(origin.x - thick, origin.y + pass * lines, 0);
            GL.Vertex3(origin.x - thick, origin.y + pass * lines + thick, 0);
            GL.Vertex3(origin.x + pass * columns - pass, origin.y + pass * lines + thick, 0);
            GL.Vertex3(origin.x + pass * columns - pass, origin.y + pass * lines, 0);
            //13
            GL.Vertex3(origin.x, origin.y, 0);
            GL.Vertex3(origin.x - thick, origin.y, 0);
            GL.Vertex3(origin.x - thick, origin.y + lines * pass, 0);
            GL.Vertex3(origin.x, origin.y + lines * pass, 0);
            //14
            GL.Vertex3(origin.x - pass, origin.y + thick, 0);
            GL.Vertex3(origin.x - pass, origin.y, 0);
            GL.Vertex3(origin.x, origin.y, 0);
            GL.Vertex3(origin.x, origin.y + thick, 0);
            //15
            GL.Vertex3(origin.x - pass, origin.y, 0);
            GL.Vertex3(origin.x - pass + thick, origin.y, 0);
            GL.Vertex3(origin.x - pass + thick, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x - pass, origin.y + pass * lines + pass, 0);
            //16
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y + pass * lines + pass, 0);
            GL.Vertex3(origin.x - 4 * pass - thick, origin.y + pass * lines + pass + thick, 0);
            GL.Vertex3(origin.x - pass + thick, origin.y + pass * lines + pass + thick, 0);
            GL.Vertex3(origin.x - pass + thick, origin.y + pass * lines + pass, 0);
        }

#pragma warning disable 649
        [SerializeField] private int lines = 4;
        [SerializeField] private int columns = 11;
        [SerializeField] private float thick = .2f;
        [SerializeField] private float pass = 4f;

        [Space, SerializeField] private Vector2 origin;

        [Space, SerializeField] private Material material;
#pragma warning restore 649
    }
}
