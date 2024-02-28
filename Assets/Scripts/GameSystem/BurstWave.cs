using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class BurstWave : MonoBehaviour
    {
        [SerializeField] private List<BurstsPositions> _burstWaves;
        [SerializeField] private GameObject _burstPrefab;

        private Coroutine _coroutine;

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void PlayParticle()
        {
            _coroutine = StartCoroutine(EmitBurstWave());
        }

        private IEnumerator EmitBurstWave()
        {
            foreach (BurstsPositions burstPositions in _burstWaves)
            {
                foreach (Transform position in burstPositions.Positions)
                {
                    GameObject burstInstance = Instantiate(_burstPrefab, position.position, Quaternion.identity);
                    ParticleSystem particleSystem = burstInstance.GetComponent<ParticleSystem>();
                    particleSystem.Play();
                }

                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}