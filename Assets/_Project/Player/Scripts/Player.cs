using _Project.Data.Scripts;
using _Project.Input.Scripts;
using UnityEngine;

namespace _Project.Player.Scripts
{
    public class Player : MonoBehaviour
    {
        #region Properties

        public PlayerData Data => player;

        #endregion

        #region Lifecyle

        private void OnEnable() => DataEvent<InputData>.call += OnInput;

        private void OnDisable() => DataEvent<InputData>.call -= OnInput;

        private void FixedUpdate() => player.origin += _direction * speed * Time.deltaTime;

        #endregion

        private void OnInput(InputData data) => _direction = data.Get<Vector2>();

        private Vector2 _direction;

#pragma warning disable 649
        [SerializeField] private float speed;

        [Space, SerializeField] private PlayerData player;
#pragma warning restore 649
    }
}
