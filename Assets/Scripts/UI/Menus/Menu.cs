using System;
using UnityEngine;

[RequireComponent (typeof(Canvas))]
public class Menu : MonoBehaviour
{   
    private Canvas _canvas;

    public event Action Opened;
    public event Action Closed;

    private void Awake()
    {
        _canvas = GetComponent<Canvas> ();
    }

    public virtual void Open()
    {
        _canvas.enabled = true; 
        Opened?.Invoke ();
    }

    public virtual void Close()
    {
        _canvas.enabled = false;
        Closed?.Invoke ();
    }
}
