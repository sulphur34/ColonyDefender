using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private GameControls _gameControls;

    public UnityEvent<Vector3> Clicked;

    private void Awake()
    {
        _gameControls = GetComponent<GameControls>();
    }

    private void OnEnable()
    {
        _gameControls.Enable();
    }

    private void OnDisable()
    {
        _gameControls.Disable();
    }

    private void Start()
    {
        _gameControls.AddTurret.Click.performed += _ => OnClick();
    }

    private void OnClick()
    {
        Vector2 cursorPosition = _gameControls.AddTurret.Position.ReadValue<Vector2>();
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Clicked.Invoke(cursorPosition);
    }
}
