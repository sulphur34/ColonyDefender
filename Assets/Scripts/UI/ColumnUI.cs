using UnityEngine;
using UnityEngine.Events;

public class ColumnUI : MonoBehaviour
{
    [SerializeField] private int _columnNumber;

    public UnityEvent<int> Clicked;

    public void OnClick()
    {
        Clicked.Invoke(_columnNumber);
    }
}
