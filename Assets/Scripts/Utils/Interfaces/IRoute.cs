using UnityEngine;

public interface IRoute
{
    public Vector3 SpawnPoint { get; }

    public Vector3 GetNextPoint();
}
