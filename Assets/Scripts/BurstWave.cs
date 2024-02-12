using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (BurstsPositions BurstPositions in _burstWaves)
        {
            foreach (Transform position in BurstPositions.Positions)
            {
                GameObject burstInstance = Instantiate(_burstPrefab, position.position, Quaternion.identity);
                ParticleSystem particleSystem = burstInstance.GetComponent<ParticleSystem>();
                particleSystem.Play();
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}

[System.Serializable]
public class BurstsPositions
{
    [SerializeField] public Transform[] Positions;
}
