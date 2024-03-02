using UnityEngine;

namespace Utils.Interfaces
{
    public interface IRoute
    {
        public Vector3 SpawnPoint { get; }

        public Vector3 GetNextPoint();
    }
}