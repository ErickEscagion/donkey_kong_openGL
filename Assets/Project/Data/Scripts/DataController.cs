using System.Collections.Generic;

namespace Project.Data.Scripts
{
    public static class DataController<T>
        where T : struct
    {
        public static void Add(T data) => _data.Add(typeof(T).GetHashCode(), data);

        public static T Get() => _data[typeof(T).GetHashCode()];

        public static void Remove(T data) => _data.Remove(typeof(T).GetHashCode());

        private static readonly Dictionary<int, T> _data = new Dictionary<int, T>();
    }
}
