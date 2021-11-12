using UnityEngine.Events;

namespace _Project.Data.Scripts
{
    public static class DataEvent<T>
        where T : struct
    {
        public static event UnityAction<T> on;

        public static void Send(T value) => on?.Invoke(value);
    }
}
