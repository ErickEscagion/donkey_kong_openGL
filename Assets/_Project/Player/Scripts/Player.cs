using System.Linq;
using _Project.Collider.Scripts;
using _Project.Data.Scripts;
using _Project.Enemy.Scripts;
using _Project.Input.Scripts;
using _Project.Levels._Shared.Scripts;
using UnityEngine;

namespace _Project.Player.Scripts
{
    public class Player : MonoBehaviour
    {
        #region Properties

        private Vector2 Direction
        {
            get => _direction;
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

                _direction = value;
            }
        }

        public PlayerData Data => player;

        #endregion

        #region Lifecyle

        private void Awake()
        {
            _finishLine = GetComponent<FinishLine.Scripts.FinishLine>();
            _enemies = GetComponent<Enemies>();
            _colliders = GetComponent<RectCollider2s>();
        }

        private void OnEnable() => DataEvent<InputData>.call += OnInput;

        private void OnDisable() => DataEvent<InputData>.call -= OnInput;

        private void FixedUpdate()
        {
            if (player.origin.x + player.size > _finishLine.Data.origin.x - _finishLine.Data.width / 2 &&
                player.origin.x - player.size < _finishLine.Data.origin.x + _finishLine.Data.width / 2 &&
                player.origin.y + player.size > _finishLine.Data.origin.y - _finishLine.Data.height / 2 &&
                player.origin.y - player.size < _finishLine.Data.origin.y + _finishLine.Data.height / 2)
            {
                Win();
            }

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

            var futurePosition = player.origin + Direction * speed * Time.deltaTime;

            if (_colliders.Data.Any(collider =>
                futurePosition.x + player.size > collider.origin.x - collider.width / 2 &&
                futurePosition.x - player.size < collider.origin.x + collider.width / 2 &&
                futurePosition.y + player.size > collider.origin.y - collider.height / 2 &&
                futurePosition.y - player.size < collider.origin.y + collider.height / 2))
            {
                return;
            }

            player.origin = futurePosition;
        }

        #endregion

        private void Kill()
        {
            enabled = false;
            DataEvent<LevelState>.Send(LevelState.Defeat);
        }

        private void Win()
        {
            enabled = false;
            DataEvent<LevelState>.Send(LevelState.Victory);
        }

        private void OnInput(InputData data) => Direction = data.Get<Vector2>();

        private Vector2 _direction;

        private Enemies _enemies;
        private RectCollider2s _colliders;
        private FinishLine.Scripts.FinishLine _finishLine;
        private readonly bool[] _allowedDirections = Enumerable.Repeat(true, 4).ToArray();

#pragma warning disable 649
        [SerializeField] private float speed;

        [Space, SerializeField] private PlayerData player;
#pragma warning restore 649
    }
}
