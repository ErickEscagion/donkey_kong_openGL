using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Enemy.Scripts
{
    public class Enemies : MonoBehaviour
    {
        #region Properties

        public IEnumerable<Enemy> Data => enemies;

        #endregion

        #region Lifecycle

        private void Start()
        {
            foreach (var t in enemies)
            {
                StartCoroutine(MoveCoroutine(t));
            }
        }

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            GL.Begin(GL.QUADS);

            foreach (var enemy in enemies)
            {
                Draw(enemy);
            }

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private static void Draw(Enemy enemy)
        {
            GL.Color(enemy.color);

            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y - enemy.size, 0);
            GL.Vertex3(enemy.origin.x - enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y + enemy.size, 0);
            GL.Vertex3(enemy.origin.x + enemy.size, enemy.origin.y - enemy.size, 0);
        }

        private IEnumerator MoveCoroutine(Enemy enemy)
        {
            var time = 0f;
            var index = enemy.lastPointIndex + 1 > enemy.points.Length - 1 ? 0 : enemy.lastPointIndex + 1;

            while (time < enemy.animationTime)
            {
                time += Time.deltaTime;
                enemy.origin = Vector2.Lerp(
                    enemy.points[enemy.lastPointIndex],
                    enemy.points[index],
                    time / enemy.animationTime);

                yield return null;
            }

            enemy.lastPointIndex = index;
            StartCoroutine(MoveCoroutine(enemy));
        }

#pragma warning disable 649
        [SerializeField] private Material material;
        [SerializeField] private Enemy[] enemies;
#pragma warning restore 649
    }
}
