using UnityEngine;

namespace _Project.Enemy.Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(Enemies))]
    internal class EnemyRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            GL.Begin(GL.QUADS);

            foreach (var enemy in enemies.Data)
            {
                Draw(enemy);
            }

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private void Draw(Enemy enemy)
        {
            GL.Color(Color.black);

            GL.Vertex3(enemy.origin.x - enemy.size - borderWidth, enemy.origin.y - enemy.size - borderWidth, 0);
            GL.Vertex3(enemy.origin.x - enemy.size - borderWidth, enemy.origin.y + enemy.size + borderWidth, 0);
            GL.Vertex3(enemy.origin.x + enemy.size + borderWidth, enemy.origin.y + enemy.size + borderWidth, 0);
            GL.Vertex3(enemy.origin.x + enemy.size + borderWidth, enemy.origin.y - enemy.size - borderWidth, 0);

            GL.Color(enemy.color);

            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y - enemy.size, 0);
            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y - enemy.size, 0);
        }


#pragma warning disable 649
        [SerializeField] private float borderWidth = .1f;

        [Header("Assets"), SerializeField] private Material material;

        [Header("Scene"), SerializeField] private Enemies enemies;
#pragma warning restore 649
    }
}
