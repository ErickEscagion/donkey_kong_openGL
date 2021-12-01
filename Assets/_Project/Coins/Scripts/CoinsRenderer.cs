using UnityEngine;

namespace _Project.Coins.Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(Coins))]
    public class CoinsRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            if (coins.Data != null)
            {
                GL.Begin(GL.QUADS);

                foreach (var coin in coins.Data)
                {
                    if (!coin.active)
                    {
                        continue;
                    }

                    Draw(coin);
                }
            }

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private void Draw(Coin coin)
        {
            GL.Color(Color.black);

            GL.Vertex3(coin.origin.x - coin.size - borderWidth, coin.origin.y - coin.size - borderWidth, 0);
            GL.Vertex3(coin.origin.x - coin.size - borderWidth, coin.origin.y + coin.size + borderWidth, 0);
            GL.Vertex3(coin.origin.x + coin.size + borderWidth, coin.origin.y + coin.size + borderWidth, 0);
            GL.Vertex3(coin.origin.x + coin.size + borderWidth, coin.origin.y - coin.size - borderWidth, 0);

            GL.Color(coin.color);

            GL.Vertex3(coin.origin.x - coin.size, coin.origin.y - coin.size, 0);
            GL.Vertex3(coin.origin.x - coin.size, coin.origin.y + coin.size, 0);
            GL.Vertex3(coin.origin.x + coin.size, coin.origin.y + coin.size, 0);
            GL.Vertex3(coin.origin.x + coin.size, coin.origin.y - coin.size, 0);
        }

#pragma warning disable 649
        [SerializeField] private float borderWidth = .1f;

        [Header("Assets"), SerializeField] private Material material;

        [Header("Scene"), SerializeField] private Coins coins;
#pragma warning restore 649
    }
}
