using UnityEngine;

public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject _modelPrefab;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
}
