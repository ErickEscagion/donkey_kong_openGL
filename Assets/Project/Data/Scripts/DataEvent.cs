using UnityEngine.Events;

namespace Project.Data.Scripts
{
    public static class DataEvent<T>
        where T : struct
    {
        public static event UnityAction<T> on;
    }
}
