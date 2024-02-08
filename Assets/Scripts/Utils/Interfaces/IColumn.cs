using System.Collections;
using UnityEngine;

public interface IColumn
{
    Vector3 SpawnPosition { get; }

    IEnumerator GetEnumerator();

    void Collapse();

    bool TryGetFreeCell(out ICell cell);

    bool TryGetNextOccupiedCell(ICell Cell, out ICell nextCell);
}
