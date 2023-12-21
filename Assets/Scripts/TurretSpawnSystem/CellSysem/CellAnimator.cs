using System.Collections;
using UnityEngine;

public class CellAnimator : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _scaleSpeed;

    public delegate void AnimationEndEvent(Turret turret);
        
    public IEnumerator MoveTurret(Turret turret, Vector3 position, AnimationEndEvent animationEnd)
    {
        float minDistance = 0.1f;

        while (Vector3.Distance(turret.transform.position, position) > minDistance)
        {
            turret.transform.position = Vector3.MoveTowards(turret.transform.position, position, _moveSpeed * Time.deltaTime);
            yield return null;
        }

        animationEnd(turret);
    }

    public IEnumerator ShrinkTurret(Turret turret, AnimationEndEvent animationEnd) 
    {
        float minScaleValue = 0.1f;

        while (Vector3.Distance(turret.transform.localScale, Vector3.zero) > minScaleValue)
        {
            turret.transform.localScale = Vector3.MoveTowards(turret.transform.localScale, Vector3.zero, _scaleSpeed * Time.deltaTime);
            yield return null;
        }

        animationEnd(turret);
    }
}
