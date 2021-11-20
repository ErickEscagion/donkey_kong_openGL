using System.Linq;
using _Project._Core.Scripts;
using _Project.Data.Scripts;
using _Project.Enemy.Scripts;
using _Project.Input.Scripts;
using UnityEngine;

namespace _Project.Player.Scripts
{
    public class Player : MonoBehaviour
    {
        #region Properties

        private Vector2 Direction
        {
            get => _directions;
            set
            {
                if (!_allowedDirections[0]) // top
                    value.y = value.y > 0 ? 0 : value.y;

                if (!_allowedDirections[1]) // right
                    value.x = value.x > 0 ? 0 : value.x;

                if (!_allowedDirections[3]) // bottom
                    value.y = value.y < 0 ? 0 : value.y;

                if (!_allowedDirections[3]) // left
                    value.x = value.x < 0 ? 0 : value.x;

                _directions = value;
            }
        }

        public PlayerData Data => player;

        #endregion

        #region Lifecyle

        private void Awake() => _enemies = GetComponent<Enemies>();

        private void OnEnable() => DataEvent<InputData>.call += OnInput;

        private void OnDisable() => DataEvent<InputData>.call -= OnInput;

        private void FixedUpdate()
        {
            foreach (var enemy in _enemies.Data)
            {
                if (player.origin.x + player.size > enemy.origin.x - enemy.size &&
                    player.origin.x - player.size < enemy.origin.x + enemy.size &&
                    player.origin.y + player.size > enemy.origin.y - enemy.size &&
                    player.origin.y - player.size < enemy.origin.y + enemy.size)
                {
                    Kill();
                }
            }

            player.origin += Direction * speed * Time.deltaTime;
        }

        #endregion

        private void Kill()
        {
            enabled = false;
            DataEvent<LevelState>.Send(LevelState.Defeat);
        }

        private void OnInput(InputData data) => Direction = data.Get<Vector2>();

        private Vector2 _directions;

        private Enemies _enemies;
        private readonly bool[] _allowedDirections = Enumerable.Repeat(true, 4).ToArray();

#pragma warning disable 649
        [SerializeField] private float speed;

        [Space, SerializeField] private PlayerData player;
#pragma warning restore 649
    }
}
