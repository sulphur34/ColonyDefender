using UnityEngine;

public interface IRoute
{
    Vector3 SpawnPoint { get; }

    Vector3 GetNextPoint();
}
