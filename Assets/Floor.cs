using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Material mat;

    private void OnPostRender()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(Color.red);

        //Baixo 
            //Linha de baixo
            GL.Vertex3(0, 0.2f, 0);
            GL.Vertex3(0, 0.0f, 0);
            GL.Vertex3(55, 0.0f, 0);
            GL.Vertex3(55, 0.2f, 0);

            GL.Vertex3(55, 0.2f, 0);
            GL.Vertex3(55, 0.0f, 0);
            GL.Vertex3(100, 2.8f, 0);
            GL.Vertex3(100, 3.0f, 0);
            //Linha de cima
            GL.Vertex3(0, 0.8f, 0);
            GL.Vertex3(0, 1.0f, 0);
            GL.Vertex3(55, 1.0f, 0);
            GL.Vertex3(55, 0.8f, 0);

            GL.Vertex3(55, 1.0f, 0);
            GL.Vertex3(55, 0.8f, 0);
            GL.Vertex3(100, 3.8f, 0);
            GL.Vertex3(100, 4.0f, 0);
            //Meio das linhas retas
            for (int i = 0; i < 55; i += 2)
            {
                GL.Vertex3(0 + i, 0.0f, 0);
                GL.Vertex3(0 + i, 0.3f, 0);
                GL.Vertex3(1 + i, 0.7f, 0);
                GL.Vertex3(1 + i, 1.0f, 0);

                GL.Vertex3(2 + i, 0.0f, 0);
                GL.Vertex3(2 + i, 0.3f, 0);
                GL.Vertex3(1 + i, 0.7f, 0);
                GL.Vertex3(1 + i, 1.0f, 0);
            }
            //Meio das linhas tortas
            float j = 0;
            for (int i = 0; i < 44; i += 2, j += 0.1375f)
            {
                GL.Vertex3(56 + i, 0.0f + j, 0);
                GL.Vertex3(56 + i, 0.3f + j, 0);
                GL.Vertex3(57 + i, 0.7f + j, 0);
                GL.Vertex3(57 + i, 1.0f + j, 0);

                GL.Vertex3(58 + i, 0.0f + j, 0);
                GL.Vertex3(58 + i, 0.3f + j, 0);
                GL.Vertex3(57 + i, 0.7f + j, 0);
                GL.Vertex3(57 + i, 1.0f + j, 0);
            }
        //Baixo - Centro
            //Linha de baixo
            GL.Vertex3(84, 8.2f, 0);
            GL.Vertex3(84, 8f, 0);
            GL.Vertex3(0, 10.8f, 0);
            GL.Vertex3(0, 11.0f, 0);
            //Linha de cima
            GL.Vertex3(84, 9.0f, 0);
            GL.Vertex3(84, 8.8f, 0);
            GL.Vertex3(0, 11.8f, 0);
            GL.Vertex3(0, 12f, 0);
            //Meio das linhas
            j = 0;
            for (int i = 0; i < 84; i += 2, j += 0.0695f)
            {
                GL.Vertex3(0 + i, 10.8f - j, 0);
                GL.Vertex3(0 + i, 11.1f - j, 0);
                GL.Vertex3(1 + i, 11.7f - j, 0);
                GL.Vertex3(1 + i, 12.0f - j, 0);

                GL.Vertex3(2 + i, 10.8f - j, 0);
                GL.Vertex3(2 + i, 11.1f - j, 0);
                GL.Vertex3(1 + i, 11.7f - j, 0);
                GL.Vertex3(1 + i, 12.0f - j, 0);
            }

        //Centro
            //Linha de baixo
            GL.Vertex3(16, 16.2f, 0);
            GL.Vertex3(16, 16f, 0);
            GL.Vertex3(100, 18.8f, 0);
            GL.Vertex3(100, 19.0f, 0);
            //Linha de cima
            GL.Vertex3(16, 17.0f, 0);
            GL.Vertex3(16, 16.8f, 0);
            GL.Vertex3(100, 19.8f, 0);
            GL.Vertex3(100, 20f, 0);
            //Meio das linhas
            j = 0;
            for (int i = 0; i < 84; i += 2, j += 0.071f)
            {
                GL.Vertex3(16 + i, 16.0f + j, 0);
                GL.Vertex3(16 + i, 16.3f + j, 0);
                GL.Vertex3(17 + i, 16.7f + j, 0);
                GL.Vertex3(17 + i, 17.0f + j, 0);

                GL.Vertex3(18 + i, 16.0f + j, 0);
                GL.Vertex3(18 + i, 16.3f + j, 0);
                GL.Vertex3(17 + i, 16.7f + j, 0);
                GL.Vertex3(17 + i, 17.0f + j, 0);
            }

        //Cima - Centro
            //Linha de baixo
            GL.Vertex3(84, 26.2f, 0);
            GL.Vertex3(84, 26f, 0);
            GL.Vertex3(0, 28.8f, 0);
            GL.Vertex3(0, 29.0f, 0);
            //Linha de cima
            GL.Vertex3(84, 27.0f, 0);
            GL.Vertex3(84, 26.8f, 0);
            GL.Vertex3(0, 29.8f, 0);
            GL.Vertex3(0, 30f, 0);
            //Meio das linhas
            j = 0;
            for (int i = 0; i < 84; i += 2, j += 0.0695f)
            {
                GL.Vertex3(0 + i, 28.8f - j, 0);
                GL.Vertex3(0 + i, 29.1f - j, 0);
                GL.Vertex3(1 + i, 29.7f - j, 0);
                GL.Vertex3(1 + i, 30.0f - j, 0);

                GL.Vertex3(2 + i, 28.8f - j, 0);
                GL.Vertex3(2 + i, 29.1f - j, 0);
                GL.Vertex3(1 + i, 29.7f - j, 0);
                GL.Vertex3(1 + i, 30.0f - j, 0);
            }
        //Cima
            //Linha de baixo
            GL.Vertex3(16, 36.2f, 0);
            GL.Vertex3(16, 36f, 0);
            GL.Vertex3(50, 38.8f, 0);
            GL.Vertex3(50, 39.0f, 0);

            GL.Vertex3(50, 38.8f, 0);
            GL.Vertex3(50, 39.0f, 0);
            GL.Vertex3(100, 39.0f, 0);
            GL.Vertex3(100, 38.8f, 0);
            //Linha de cima
            GL.Vertex3(16, 37.0f, 0);
            GL.Vertex3(16, 36.8f, 0);
            GL.Vertex3(50, 39.8f, 0);
            GL.Vertex3(50, 40f, 0);

            GL.Vertex3(50, 39.8f, 0);
            GL.Vertex3(50, 40.0f, 0);
            GL.Vertex3(100, 40.0f, 0);
            GL.Vertex3(100, 39.8f, 0);
            //Meio das linhas
            j = 0;
            for (int i = 0; i < 34; i += 2, j += 0.185f)
            {
                GL.Vertex3(16 + i, 36.0f + j, 0);
                GL.Vertex3(16 + i, 36.3f + j, 0);
                GL.Vertex3(17 + i, 36.7f + j, 0);
                GL.Vertex3(17 + i, 37.0f + j, 0);

                GL.Vertex3(18 + i, 36.0f + j, 0);
                GL.Vertex3(18 + i, 36.3f + j, 0);
                GL.Vertex3(17 + i, 36.7f + j, 0);
                GL.Vertex3(17 + i, 37.0f + j, 0);
            }
            //Meio das linhas retas
            for (int i = 0; i < 50; i += 2)
            {
                GL.Vertex3(50 + i, 39.0f, 0);
                GL.Vertex3(50 + i, 39.3f, 0);
                GL.Vertex3(51 + i, 39.7f, 0);
                GL.Vertex3(51 + i, 40.0f, 0);

                GL.Vertex3(52 + i, 39.0f, 0);
                GL.Vertex3(52 + i, 39.3f, 0);
                GL.Vertex3(51 + i, 39.7f, 0);
                GL.Vertex3(51 + i, 40.0f, 0);
            }
        //Chegada
            //Linha de baixo
            GL.Vertex3(56, 46.8f, 0);
            GL.Vertex3(56, 47.0f, 0);
            GL.Vertex3(70, 47.0f, 0);
            GL.Vertex3(70, 46.8f, 0);
            //Linha de cima
            GL.Vertex3(56, 47.8f, 0);
            GL.Vertex3(56, 48.0f, 0);
            GL.Vertex3(70, 48.0f, 0);
            GL.Vertex3(70, 47.8f, 0);
            //Meio das linhas
            for (int i = 0; i < 14; i += 2)
            {
                GL.Vertex3(56 + i, 47.0f, 0);
                GL.Vertex3(56 + i, 47.3f, 0);
                GL.Vertex3(57 + i, 47.7f, 0);
                GL.Vertex3(57 + i, 48.0f, 0);

                GL.Vertex3(58 + i, 47.0f, 0);
                GL.Vertex3(58 + i, 47.3f, 0);
                GL.Vertex3(57 + i, 47.7f, 0);
                GL.Vertex3(57 + i, 48.0f, 0);
            }

        GL.End();
        GL.PopMatrix();
    }
}
