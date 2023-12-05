using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(EnhancementSystem))]
[RequireComponent(typeof(TurretFactory))]
public class GameHandler : MonoBehaviour
{    
    [SerializeField] private Barrier _barrier;
    [SerializeField] private CellBoard _cellBoard;
        
    private EnhancementSystem _enhancementSystem;
    private TurretFactory _turretFactory;
    private int _minTurretLevel;

    public UnityEvent GameStarted;
    public UnityEvent GameLost;
    public UnityEvent GameWin;

    private void Awake()
    {
        _minTurretLevel = 1;
        _enhancementSystem = GetComponent<EnhancementSystem>();
        _turretFactory = GetComponent<TurretFactory>();
        _barrier.EnemyInvaded += OnGameLost;
        _cellBoard.Merged.AddListener(OnMerge);
    }    

    public void OnColumnClick(int columnIndex)
    {
        OnMerge(_minTurretLevel, columnIndex);
    }

    private void OnMerge(int turretLevel, int columnIndex)
    {
        if(_cellBoard.Columns[columnIndex].TryGetFreeCell(out ICell cell))
            _cellBoard.AddTurret(cell, _turretFactory.Build(turretLevel));
    }

    private void OnGameLost()
    {
        GameLost.Invoke();
    }
}
