namespace Utils.Interfaces
{
    public interface IFactory<T>
    {
        public T Build(float levelIndex);
    }
}