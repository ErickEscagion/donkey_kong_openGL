using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Stairs : MonoBehaviour
{
    public Material mat;

    private void OnPostRender()
    {
        GL.PushMatrix();
        mat.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(Color.blue);
        //Escada completa de baixo
        //Laterais
        GL.Vertex3(70, 2, 0);
        GL.Vertex3(70, 8.5f, 0);
        GL.Vertex3(70.5f, 8.5f, 0);
        GL.Vertex3(70.5f, 2, 0);
        GL.Vertex3(74, 2.2f, 0);
        GL.Vertex3(74, 8.3f, 0);
        GL.Vertex3(74.5f, 8.3f, 0);
        GL.Vertex3(74.5f, 2.2f, 0);
        //Degraus
        for (int i = 0; i < 6; i += 2)
        {
            GL.Vertex3(70, 3 + i, 0);
            GL.Vertex3(70, 3.5f + i, 0);
            GL.Vertex3(74, 3.5f + i, 0);
            GL.Vertex3(74, 3 + i, 0);
        }
        //Semi escada de baixo
        //Laterais
        GL.Vertex3(30, 1, 0);
        GL.Vertex3(30, 2.5f, 0);
        GL.Vertex3(30.5f, 2.5f, 0);
        GL.Vertex3(30.5f, 1, 0);
        GL.Vertex3(34, 1, 0);
        GL.Vertex3(34, 2.5f, 0);
        GL.Vertex3(34.5f, 2.5f, 0);
        GL.Vertex3(34.5f, 1, 0);
        GL.Vertex3(30, 8, 0);
        GL.Vertex3(30, 9.8f, 0);
        GL.Vertex3(30.5f, 9.8f, 0);
        GL.Vertex3(30.5f, 8, 0);
        GL.Vertex3(34, 8, 0);
        GL.Vertex3(34, 9.7f, 0);
        GL.Vertex3(34.5f, 9.7f, 0);
        GL.Vertex3(34.5f, 8, 0);
        //Degraus
        GL.Vertex3(30, 1.5f, 0);
        GL.Vertex3(30, 2, 0);
        GL.Vertex3(34, 2, 0);
        GL.Vertex3(34, 1.5f, 0);
        GL.Vertex3(30, 8.7f, 0);
        GL.Vertex3(30, 9.2f, 0);
        GL.Vertex3(34, 9.2f, 0);
        GL.Vertex3(34, 8.7f, 0);
        //Escada completa 2 fileira (esquerda)
        //Laterais
        GL.Vertex3(20, 11.3f, 0);
        GL.Vertex3(20, 16.2f, 0);
        GL.Vertex3(20.5f, 16.2f, 0);
        GL.Vertex3(20.5f, 11.3f, 0);
        GL.Vertex3(24, 11.2f, 0);
        GL.Vertex3(24, 16.3f, 0);
        GL.Vertex3(24.5f, 16.3f, 0);
        GL.Vertex3(24.5f, 11.2f, 0);
        //Degraus
        for (int i = 0; i < 4; i += 2)
        {
            GL.Vertex3(20, 12.5f + i, 0);
            GL.Vertex3(20, 13.0f + i, 0);
            GL.Vertex3(24, 13.0f + i, 0);
            GL.Vertex3(24, 12.5f + i, 0);
        }
        //Escada completa 2 fileira (direita)
        //Laterais
        GL.Vertex3(50, 10.3f, 0);
        GL.Vertex3(50, 17.2f, 0);
        GL.Vertex3(50.5f, 17.2f, 0);
        GL.Vertex3(50.5f, 10.3f, 0);
        GL.Vertex3(54, 10.2f, 0);
        GL.Vertex3(54, 17.3f, 0);
        GL.Vertex3(54.5f, 17.3f, 0);
        GL.Vertex3(54.5f, 10.2f, 0);
        //Degraus
        for (int i = 0; i < 6; i += 2)
        {
            GL.Vertex3(50, 11.5f + i, 0);
            GL.Vertex3(50, 12.0f + i, 0);
            GL.Vertex3(54, 12.0f + i, 0);
            GL.Vertex3(54, 11.5f + i, 0);
        }
        //Escada completa 3 fileira 
        //Laterais
        GL.Vertex3(76, 19.2f, 0);
        GL.Vertex3(76, 26.2f, 0);
        GL.Vertex3(76.5f, 26.2f, 0);
        GL.Vertex3(76.5f, 19.2f, 0);
        GL.Vertex3(80, 19.4f, 0);
        GL.Vertex3(80, 26.2f, 0);
        GL.Vertex3(80.5f, 26.2f, 0);
        GL.Vertex3(80.5f, 19.4f, 0);
        //Degraus
        for (int i = 0; i < 6; i += 2)
        {
            GL.Vertex3(76, 20.5f + i, 0);
            GL.Vertex3(76, 21.0f + i, 0);
            GL.Vertex3(80, 21.0f + i, 0);
            GL.Vertex3(80, 20.5f + i, 0);
        }
        //Semi escada da 3 fileira
        //Laterais
        GL.Vertex3(36, 17.8f, 0);
        GL.Vertex3(36, 19.5f, 0);
        GL.Vertex3(36.5f, 19.5f, 0);
        GL.Vertex3(36.5f, 17.8f, 0);
        GL.Vertex3(40, 17.8f, 0);
        GL.Vertex3(40, 19.5f, 0);
        GL.Vertex3(40.5f, 19.5f, 0);
        GL.Vertex3(40.5f, 17.8f, 0);
        GL.Vertex3(36, 26, 0);
        GL.Vertex3(36, 27.6f, 0);
        GL.Vertex3(36.5f, 27.6f, 0);
        GL.Vertex3(36.5f, 26, 0);
        GL.Vertex3(40, 26, 0);
        GL.Vertex3(40, 27.5f, 0);
        GL.Vertex3(40.5f, 27.5f, 0);
        GL.Vertex3(40.5f, 26, 0);
        //Degraus
        GL.Vertex3(36, 18.3f, 0);
        GL.Vertex3(36, 18.8f, 0);
        GL.Vertex3(40, 18.8f, 0);
        GL.Vertex3(40, 18.3f, 0);
        GL.Vertex3(36, 26.5f, 0);
        GL.Vertex3(36, 27.0f, 0);
        GL.Vertex3(40, 27.0f, 0);
        GL.Vertex3(40, 26.5f, 0);
        //Escada incompleta penultima fileira 
        //Laterais
        GL.Vertex3(74.5f, 39.0f, 0);
        GL.Vertex3(74.5f, 36.5f, 0);
        GL.Vertex3(75.0f, 36.5f, 0);
        GL.Vertex3(75.0f, 39.0f, 0);
        GL.Vertex3(78.5f, 39.0f, 0);
        GL.Vertex3(78.5f, 36.5f, 0);
        GL.Vertex3(79.0f, 36.5f, 0);
        GL.Vertex3(79.0f, 39.0f, 0);
        //Degraus
        GL.Vertex3(75, 37.5f , 0);
        GL.Vertex3(75, 38.0f , 0);
        GL.Vertex3(79, 38.0f , 0);
        GL.Vertex3(79, 37.5f , 0);

        //Escada completa penultima fileira
        //Laterais
        GL.Vertex3(20, 29.3f, 0);
        GL.Vertex3(20, 36.4f, 0);
        GL.Vertex3(20.5f, 36.4f, 0);
        GL.Vertex3(20.5f, 29.3f, 0);

        GL.Vertex3(24, 29.1f, 0);
        GL.Vertex3(24, 36.7f, 0);
        GL.Vertex3(24.5f, 36.7f, 0);
        GL.Vertex3(24.5f, 29.1f, 0);
        //Degraus
        for (int i = 0; i < 8; i += 2)
        {
            GL.Vertex3(20, 29.5f + i, 0);
            GL.Vertex3(20, 30.0f + i, 0);
            GL.Vertex3(24, 30.0f + i, 0);
            GL.Vertex3(24, 29.5f + i, 0);
        }


        //Escada completa ultima fileira(esquerda) 
        //Laterais
        GL.Vertex3(56, 40.0f, 0);
        GL.Vertex3(56, 46.75f, 0);
        GL.Vertex3(56.5f, 46.75f, 0);
        GL.Vertex3(56.5f, 40.0f, 0);
        GL.Vertex3(60, 40.0f, 0);
        GL.Vertex3(60, 46.75f, 0);
        GL.Vertex3(60.5f, 46.75f, 0);
        GL.Vertex3(60.5f, 40.0f, 0);
        //Degraus
        for (int i = 0; i < 6; i += 2)
        {
            GL.Vertex3(56, 41.0f + i, 0);
            GL.Vertex3(56, 41.5f + i, 0);
            GL.Vertex3(60, 41.5f + i, 0);
            GL.Vertex3(60, 41.0f + i, 0);
        }
        //Escada completa ultima fileira(centro) 
        //Laterais
        GL.Vertex3(70, 40.0f, 0);
        GL.Vertex3(70, 56.0f, 0);
        GL.Vertex3(70.5f, 56.0f, 0);
        GL.Vertex3(70.5f, 40.0f, 0);
        GL.Vertex3(74, 40.0f, 0);
        GL.Vertex3(74, 56.0f, 0);
        GL.Vertex3(74.5f, 56.0f, 0);
        GL.Vertex3(74.5f, 40.0f, 0);
        //Degraus
        for (int i = 0; i < 16; i += 2)
        {
            GL.Vertex3(70, 40.5f + i, 0);
            GL.Vertex3(70, 41.0f + i, 0);
            GL.Vertex3(74, 41.0f + i, 0);
            GL.Vertex3(74, 40.5f + i, 0);
        }
        //Escada completa ultima fileira(direita) 
        //Laterais
        GL.Vertex3(79.0f, 40.0f, 0);
        GL.Vertex3(79.0f, 56.0f, 0);
        GL.Vertex3(79.5f, 56.0f, 0);
        GL.Vertex3(79.5f, 40.0f, 0);
        GL.Vertex3(83.0f, 40.0f, 0);
        GL.Vertex3(83.0f, 56.0f, 0);
        GL.Vertex3(83.5f, 56.0f, 0);
        GL.Vertex3(83.5f, 40.0f, 0);
        //Degraus
        for (int i = 0; i < 16; i += 2)
        {
            GL.Vertex3(79, 40.5f + i, 0);
            GL.Vertex3(79, 41.0f + i, 0);
            GL.Vertex3(83, 41.0f + i, 0);
            GL.Vertex3(83, 40.5f + i, 0);
        }
        GL.End();
        GL.PopMatrix();
    }
}
