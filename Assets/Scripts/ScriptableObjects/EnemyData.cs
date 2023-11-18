using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Data", fileName = "new enemy data", order = 53)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject _modelPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _maxHealth;
    [SerializeField] protected float _speed;
}
