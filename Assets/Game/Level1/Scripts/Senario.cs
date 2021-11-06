using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
internal class Senario : MonoBehaviour
{
    public Material mat;

    void OnPostRender()
    {
        GL.PushMatrix();
        float p1 = 19.0f, p2 = 33.5f, pass = 4f;
        int lines = 4, coluns = 11;
        walls(p1, p2, pass, lines, coluns);
        startEndFloor(p1, p2, pass, lines, coluns);
        floor(p1, p2, pass, lines, coluns);
        GL.PopMatrix();
    }
    internal void floor(float p1, float p2, float pass, int lines, int coluns)
    {
        mat.SetPass(0);
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
        GL.Vertex3(p2 + (pass * coluns) + pass, p1 + (pass * lines), 0);
        GL.Vertex3(p2 + (pass * coluns), p1 + (pass * lines), 0);
        GL.Vertex3(p2 + (pass * coluns), p1 + (pass * lines) + pass, 0);
        GL.Vertex3(p2 + (pass * coluns) + pass, p1 + (pass * lines) + pass, 0);
        GL.Color(Color.red);
        GL.Vertex3(p2 + (pass * coluns), p1 + (pass * lines), 0);
        GL.Vertex3(p2 + (pass * coluns) - pass, p1 + (pass * lines), 0);
        GL.Vertex3(p2 + (pass * coluns) - pass, p1 + (pass * lines) + pass, 0);
        GL.Vertex3(p2 + (pass * coluns), p1 + (pass * lines) + pass, 0);
        //center       
        for(int i = 0; i < lines; i++){
            for(int j = 0; j < coluns; j++){
                if (i % 2 == 0){
                    if (j % 2 == 0) GL.Color(Color.red);
                    else GL.Color(Color.blue);
                }else{
                    if (j % 2 == 0) GL.Color(Color.blue);
                    else GL.Color(Color.red);
                }
                GL.Vertex3((p2 + pass) + (j * pass), p1 + (i * pass), 0);
                GL.Vertex3(p2 + (j * pass), p1 + (i * pass), 0);
                GL.Vertex3(p2 + (j * pass), (p1 + pass) + (i * pass), 0);
                GL.Vertex3((p2 + pass) + (j * pass), (p1 + pass) + (i * pass), 0);
            }
        }
        GL.End();
    }
    internal void startEndFloor(float p1, float p2, float pass, int lines, int coluns)
    {
        mat.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(Color.green);
        //start
        GL.Vertex3((p2 - 4 * pass), p1 - pass, 0);
        GL.Vertex3((p2 - pass), p1 - pass, 0);
        GL.Vertex3((p2 - pass), p1 + (pass * lines) + pass, 0);
        GL.Vertex3((p2 - 4 * pass), p1 + (pass * lines) + pass, 0);

        //end
        GL.Vertex3(((p2 + pass * coluns) + 4 * pass), p1 - pass, 0);
        GL.Vertex3((p2 + pass * coluns + pass), p1 - pass, 0);
        GL.Vertex3((p2 + pass * coluns + pass), p1 + (pass * lines) + pass, 0);
        GL.Vertex3(((p2 + pass * coluns) + 4 * pass), p1 + (pass * lines) + pass, 0);
        GL.End();
    }
    internal void walls(float p1, float p2, float pass, int lines, int coluns)
    {
        mat.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(Color.black);
        float size = 0.7f;
        //1 - Esqueda
        GL.Vertex3(p2 - 4 * pass , p1 - pass, 0);
        GL.Vertex3(p2 - 4 * pass - size, p1 - pass, 0);
        GL.Vertex3(p2 - 4 * pass - size, p1 + pass * lines + pass, 0);
        GL.Vertex3(p2 - 4 * pass , p1 + pass * lines + pass, 0);
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
        GL.Vertex3(p2 + pass , p1 - size, 0);
        GL.Vertex3(p2 + pass , p1, 0);
        GL.Vertex3(p2 + pass * coluns, p1, 0);
        GL.Vertex3(p2 + pass * coluns, p1 - size, 0);
        //5
        GL.Vertex3(p2 + pass * coluns, p1 - size, 0);
        GL.Vertex3(p2 + pass * coluns + size, p1 - size, 0);
        GL.Vertex3(p2 + pass * coluns + size, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns, p1 + pass * lines, 0);
        //6
        GL.Vertex3(p2 + pass * coluns, p1 + pass * lines - size, 0);
        GL.Vertex3(p2 + pass * coluns, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns + pass, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns + pass, p1 + pass * lines - size, 0);
        //7
        GL.Vertex3(p2 + pass * coluns + pass - size, p1 - pass, 0);
        GL.Vertex3(p2 + pass * coluns + pass, p1 - pass, 0);
        GL.Vertex3(p2 + pass * coluns + pass, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns + pass - size, p1 + pass * lines, 0);
        //8
        GL.Vertex3(p2 + pass * coluns + pass - size, p1 - pass, 0);
        GL.Vertex3(p2 + pass * coluns + pass - size, p1 - pass - size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 - pass - size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 - pass, 0);
        //9
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 - pass - size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4 + size, p1 - pass - size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4 + size, p1 + pass * lines + pass + size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 + pass * lines + pass + size, 0);
        //10
        GL.Vertex3(p2 + pass * coluns - pass - size, p1 + pass * lines + pass, 0);
        GL.Vertex3(p2 + pass * coluns - pass - size, p1 + pass * lines + pass + size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 + pass * lines + pass + size, 0);
        GL.Vertex3(p2 + pass * coluns + pass * 4, p1 + pass * lines + pass, 0);
        //11
        GL.Vertex3(p2 + pass * coluns - pass - size, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns - pass, p1 + pass * lines, 0);
        GL.Vertex3(p2 + pass * coluns - pass, p1 + pass * lines + pass, 0);
        GL.Vertex3(p2 + pass * coluns - pass - size, p1 + pass * lines + pass, 0);
        //12
        GL.Vertex3(p2 - size, p1 + pass * lines , 0);
        GL.Vertex3(p2 - size, p1 + pass * lines + size, 0);
        GL.Vertex3(p2 + pass * coluns - pass, p1 + pass * lines + size, 0);
        GL.Vertex3(p2 + pass * coluns - pass, p1 + pass * lines, 0);
        //13
        GL.Vertex3(p2, p1, 0);
        GL.Vertex3(p2 - size, p1, 0);
        GL.Vertex3(p2 - size, p1 + lines * pass, 0);
        GL.Vertex3(p2, p1 + lines * pass, 0);
        //14
        GL.Vertex3(p2 - pass, p1+size, 0);
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
        GL.Vertex3(p2 - 4 * pass - size, p1 + pass * lines + pass  + size, 0);
        GL.Vertex3(p2 - pass + size, p1 + pass * lines + pass + size, 0);
        GL.Vertex3(p2 - pass + size, p1 + pass * lines + pass, 0);
        GL.End();
    }
}
