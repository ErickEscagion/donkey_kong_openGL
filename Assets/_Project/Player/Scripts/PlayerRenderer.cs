using UnityEngine;

namespace _Project.Player.Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(Player))]
    public class PlayerRenderer : MonoBehaviour
    {
        #region Lifecycle

        private void OnPostRender()
        {
            GL.PushMatrix();
            material.SetPass(0);

            Draw(player.Data);

            GL.End();
            GL.PopMatrix();
        }

        #endregion

        private static void Draw(PlayerData player)
        {
            GL.Begin(GL.QUADS);
            GL.Color(player.color);

            GL.Vertex3(player.origin.x - player.size, player.origin.y - player.size, 0);
            GL.Vertex3(player.origin.x - player.size, player.origin.y + player.size, 0);
            GL.Vertex3(player.origin.x + player.size, player.origin.y + player.size, 0);
            GL.Vertex3(player.origin.x + player.size, player.origin.y - player.size, 0);
        }

#pragma warning disable 649
        [SerializeField] private Player player;
        [SerializeField] private Material material;
#pragma warning restore 649
    }
}
