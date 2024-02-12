using UnityEngine;

public interface ICell 
{
    public int Row { get; }
    public int Column { get; }
    public Vector3 Position { get; }
    public float TurretLevel { get; }

    public void Initialize(int row, int column);

    public bool CanMerge(ICell cellToMerge);

    public void ReceiveTurret(ICell cellToSwap);

    public void AddTurret(Turret turret);

    public void PassTurret(ICell cell);

    public void RemoveTurret();

    public void Clear();
}
