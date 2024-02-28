using EnemySystem;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enemy Data", fileName = "new enemy data", order = 53)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyParameters _small;
        [SerializeField] private EnemyParameters _medium;
        [SerializeField] private EnemyParameters _large;
        [SerializeField] private EnemyParameters _boss;

        public Enemy EnemyPrefab => _enemyPrefab;
        public EnemyParameters Small => _small;
        public EnemyParameters Medium => _medium;
        public EnemyParameters Large => _large;
        public EnemyParameters Boss => _boss;
    }
}