using System.Collections.Generic;

namespace _Project.Data.Scripts
{
    public static class DataController<T>
        where T : struct
    {
        public static void Add(T data)
        {
            var key = typeof(T).GetHashCode();
            if (_data.ContainsKey(key))
            {
                _data[key] = data;
            }
            else
            {
                _data.Add(key, data);
            }
        }

        public static T Get() => _data[typeof(T).GetHashCode()];

        public static void Remove(T data) => _data.Remove(typeof(T).GetHashCode());

        private static readonly Dictionary<int, T> _data = new Dictionary<int, T>();
    }
}
