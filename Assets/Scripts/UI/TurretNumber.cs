using UnityEngine;

public class TurretNumber : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.forward = Vector3.up;
    }
}
