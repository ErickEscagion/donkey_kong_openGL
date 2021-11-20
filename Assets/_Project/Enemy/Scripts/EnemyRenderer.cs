using UnityEngine;

namespace _Project.Enemy.Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(Enemies))]
    internal class EnemyRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void Awake() => _enemies = GetComponent<Enemies>();

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            GL.Begin(GL.QUADS);

            foreach (var enemy in _enemies.Data)
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

        private Enemies _enemies;

#pragma warning disable 649
        [SerializeField] private float borderWidth = .1f;

        [Space, SerializeField] private Material material;
#pragma warning restore 649
    }
}
