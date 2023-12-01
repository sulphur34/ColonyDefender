using UnityEngine;

[CreateAssetMenu(menuName = "Spawn Positions", fileName = "new spawn position", order = 54)]
public class SpawnPositionsData : ScriptableObject
{
    [SerializeField] private Vector3[] _spawnPoints;

    public Vector3[] SpawnPoints => _spawnPoints;
}
