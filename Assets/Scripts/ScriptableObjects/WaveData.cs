using UnityEngine;

[CreateAssetMenu(menuName = "Wave Data", fileName = "new wave data", order = 55)]
public class WaveData : ScriptableObject
{
    [SerializeField] SpawnPositionsData _spawnPositionsData;
}
