using UnityEngine;

[CreateAssetMenu(menuName = "Wave Data", fileName = "new wave data", order = 54)]
public class WaveData : ScriptableObject
{
    [SerializeField] SpawnPositionsData spawnPositionsData;
}
