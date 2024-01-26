using UnityEngine;

public class GameLevel : Enhancement
{
    private void Awake()
    {
        SaveToken = SaveData.ProgressLevel;
    }
}
