using UnityEngine.Events;

namespace _Project.Data.Scripts
{
    public static class DataEvent<T>
        where T : struct
    {
        public static event UnityAction<T> call;

        public static void Send(T value) => call?.Invoke(value);
    }
}
