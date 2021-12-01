namespace _Project.Input.Scripts
{
    public struct InputData
    {
        public bool performing;
        public object value;

        public T Get<T>()
            where T : struct
        {
            return (T) value;
        }
    }
}
