using System.Collections;
using UnityEngine;

public class AnimationPromo : MonoBehaviour
{
    [SerializeField] private GameObject[] _turrets;

    private void Awake()
    {
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        foreach (var t in _turrets)
        {
            t.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            t.SetActive(false);
        }
    }
}
