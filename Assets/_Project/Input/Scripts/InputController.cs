using _Project.Data.Scripts;
using UnityEngine;

namespace _Project.Input.Scripts
{
    internal class InputController : MonoBehaviour
    {
        #region Lifecycle

        private void Update()
        {
            CheckKeysDown();
            CheckKeysUp();
        }

        #endregion

        private void CheckKeysDown()
        {
            foreach (var key in up)
            {
                if (!UnityEngine.Input.GetKeyDown(key))
                {
                    continue;
                }

                _direction.y = 1f;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = true,
                    value = _direction
                });
            }

            foreach (var key in right)
            {
                if (!UnityEngine.Input.GetKeyDown(key))
                {
                    continue;
                }

                _direction.x = 1f;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = true,
                    value = _direction
                });
            }

            foreach (var key in down)
            {
                if (!UnityEngine.Input.GetKeyDown(key))
                {
                    continue;
                }

                _direction.y = -1f;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = true,
                    value = _direction
                });
            }

            foreach (var key in left)
            {
                if (!UnityEngine.Input.GetKeyDown(key))
                {
                    continue;
                }

                _direction.x = -1f;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = true,
                    value = _direction
                });
            }
        }

        private void CheckKeysUp()
        {
            foreach (var key in up)
            {
                if (!UnityEngine.Input.GetKeyUp(key))
                {
                    continue;
                }

                _direction.y = 0;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = false,
                    value = _direction
                });
            }

            foreach (var key in right)
            {
                if (!UnityEngine.Input.GetKeyUp(key))
                {
                    continue;
                }

                _direction.x = 0;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = false,
                    value = _direction
                });
            }

            foreach (var key in down)
            {
                if (!UnityEngine.Input.GetKeyUp(key))
                {
                    continue;
                }

                _direction.y = 0;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = false,
                    value = _direction
                });
            }

            foreach (var key in left)
            {
                if (!UnityEngine.Input.GetKeyUp(key))
                {
                    continue;
                }

                _direction.x = 0;
                DataEvent<InputData>.Send(new InputData
                {
                    performing = false,
                    value = _direction
                });
            }
        }

        private Vector2 _direction;

#pragma warning disable 649
        [SerializeField] private KeyCode[] up;
        [SerializeField] private KeyCode[] right;
        [SerializeField] private KeyCode[] down;
        [SerializeField] private KeyCode[] left;
#pragma warning restore 649
    }
}
