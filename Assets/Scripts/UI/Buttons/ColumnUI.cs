using System;
using UnityEngine;

public class ColumnUI : MonoBehaviour
{
    [SerializeField] private int _columnNumber;

    public event Action<int> Clicked;

    public void OnClick()
    {
        Clicked?.Invoke(_columnNumber);
    }
}
