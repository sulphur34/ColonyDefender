using UnityEngine;

public class TurretsAmountLabel : TextSetter
{
    [SerializeField] GameHandler _gameHandler;    

    private void Awake()
    {
        _gameHandler.TurretAdded += SetText;
    }    
}
