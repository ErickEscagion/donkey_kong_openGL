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

            foreach (var enemy in enemies.All)
            {
                Draw(enemy);
            }

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private static void Draw(Enemy enemy)
        {
            GL.Begin(GL.QUADS);
            GL.Color(enemy.color);

            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y - enemy.size, 0);
            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y - enemy.size, 0);
        }

#pragma warning disable 649
        [SerializeField] private Material material;
        [SerializeField] private Enemies enemies;
#pragma warning restore 649
    }
}
