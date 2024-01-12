using UnityEngine;

public interface ICell 
{
    int Row { get; }
    int Column { get; }
    Vector3 Position { get; }    
    float TurretLevel { get; }

    void Initialize(int row, int column);

    bool CanMerge(ICell cellToMerge);

    void ReceiveTurret(ICell cellToSwap);

    void AddTurret(Turret turret);

    void PassTurret(ICell cell);

    void RemoveTurret();

    void Clear();
}
