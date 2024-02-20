using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMover : MonoBehaviour
{
    private IRoute _route;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _currentPoint;
    private float _distanceTolerance = 1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
        
    public void Initialize(IRoute route)
    {
        _route = route;
        _currentPoint = _route.SpawnPoint;
    }

    public void Activate()
    {
        _coroutine = StartCoroutine(CheckDestination());
    }

    public void Deactivate()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _navMeshAgent.isStopped = true;        
    }
    
    private IEnumerator CheckDestination()
    {
        bool isContinue = true;

        while (isContinue)
        {
            if (float.IsInfinity(_navMeshAgent.remainingDistance) || _navMeshAgent.remainingDistance <= _distanceTolerance)
            {
                _currentPoint = _route.GetNextPoint();
                _navMeshAgent.destination = _currentPoint;
            }

            yield return null;
        }
    }
}
