using UnityEngine;

public interface IFactory<T>
{
    public T Build(int Level);
}
