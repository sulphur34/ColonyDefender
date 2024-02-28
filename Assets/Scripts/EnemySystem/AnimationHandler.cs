using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Enemy))]
    public class AnimationHandler : MonoBehaviour
    {
        private const string MoveAnimationName = "Move";

        [SerializeField] private ParticleSystem _deathAnimation;

        private int _moveAnimationIndex;
        private Animator _animator;
        private Enemy _enemy;
        private float _minAnimationDelay = 0f;
        private float _maxAnimationDelay = 1f;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _animator = GetComponent<Animator>();
            _moveAnimationIndex = Animator.StringToHash(MoveAnimationName);
            _enemy.Died += OnDeath;
        }

        private void OnEnable()
        {
            _animator.speed = 1f;
            float delay = Random.Range(_minAnimationDelay, _maxAnimationDelay);
            _animator.Play(_moveAnimationIndex, 0, delay);
        }

        private void OnDisable()
        {
            _animator.speed = 0f;
        }

        private void OnDeath(Enemy enemy)
        {
            ParticleSystem deathParticle = Instantiate(_deathAnimation, enemy.transform.position, Quaternion.identity);
        }
    }
}
