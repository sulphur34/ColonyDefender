using System;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public event Action ProgressReseted;



    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        ProgressReseted.Invoke();
    }
}
