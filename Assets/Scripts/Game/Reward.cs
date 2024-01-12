using UnityEngine;

public class Reward
{
    public Reward(float rewardValue)
    {
       RewardValue = Mathf.Round(rewardValue); ;
    }

    public float RewardValue { get; private set; }        
}
