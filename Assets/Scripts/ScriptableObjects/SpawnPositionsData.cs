using UnityEngine;

[CreateAssetMenu(menuName = "Wave Data", fileName = "new wave data", order = 54)]
public class SpawnPositionsData : ScriptableObject
{
    [SerializeField] private Vector3[] _spawnPoints;

    public Vector3[] spawnPoints => _spawnPoints;
}
