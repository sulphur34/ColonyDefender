using UnityEngine;

[RequireComponent (typeof(Canvas))]
public class Menu : MonoBehaviour
{   
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas> ();
    }

    public virtual void Activate()
    {
        _canvas.enabled = true; 
    }

    public virtual void Deactivate()
    {
        _canvas.enabled = false;
    }
}
