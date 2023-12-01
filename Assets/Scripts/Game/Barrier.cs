using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Barrier : MonoBehaviour
{
    public UnityAction EnemyInvaded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            EnemyInvaded.Invoke();
        }
    }
}
