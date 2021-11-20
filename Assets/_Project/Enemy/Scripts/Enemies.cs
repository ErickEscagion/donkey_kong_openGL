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

        #endregion

        #region Coroutines

        private IEnumerator MoveCoroutine(Enemy enemy)
        {
            if (enemy.points.Length == 0)
            {
                yield break;
            }

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

        #endregion

#pragma warning disable 649
        [SerializeField] private Enemy[] enemies;
#pragma warning restore 649
    }
}
