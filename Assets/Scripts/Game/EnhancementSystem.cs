using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    private void Awake()
    {
        DamageMultiplier = 2.0f;
        FireRateMultiplier = 2.0f;
    }

    public float DamageMultiplier {  get; private set; }
    public  float FireRateMultiplier { get; private set; }
}
