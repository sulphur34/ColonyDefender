using UnityEngine;

public class Cell : MonoBehaviour, ICell
{
    [SerializeField] private CellAnimator _cellAnimator;
    
    private Turret _turret;
    private Coroutine _animationCoroutine;

    public void Initialize(int row, int column)
    {
        Row = row;
        Column = column;
        Position = transform.position;
    }

    public int Row { get; private set; }

    public int Column { get; private set; }

    public int TurretLevel => _turret == null ? 0 : _turret.TurretLevel;

    public Vector3 Position { get; private set; }

    public void AddTurret(Turret turret)
    {
        _turret = turret;
                
        _animationCoroutine = 
        StartCoroutine(_cellAnimator.MoveTurret(_turret, Position, (_turret) => _turret.transform.position = Position));
    }

    public bool CanMerge(ICell cellToMerge)
    {
        return TurretLevel == cellToMerge.TurretLevel;
    }

    public void RemoveTurret()
    {
        if (_turret != null)
        {
            _animationCoroutine =
            StartCoroutine(_cellAnimator.ShrinkTurret(_turret, (_turret) => Destroy(_turret.gameObject)));
            Clear();
        }              
    }
        
    public void Clear()
    {
        _turret = null;
    }

    public void ReceiveTurret(ICell cellToGetFrom)
    {
        cellToGetFrom.PassTurret(this);
    }

    public void PassTurret(ICell cellToPass)
    {
        cellToPass.AddTurret(_turret);
        _turret = null;
    }
}
