using UnityEngine;

public class EnhancementSystem : MonoBehaviour
{
    private void Awake()
    {
        DamageMultiplier = 1.0f;
        FireRateMultiplier = 1.0f;
    }

    public float DamageMultiplier {  get; private set; }
    public  float FireRateMultiplier { get; private set; }
}
