using System.Collections;
using UnityEngine;

namespace Utils.Interfaces
{
    public interface IColumn
    {
        public Vector3 SpawnPosition { get; }

        public IEnumerator GetEnumerator();

        public void Collapse();

        public bool TryGetFreeCell(out ICell cell);

        public bool TryGetNextOccupiedCell(ICell Cell, out ICell nextCell);
    }
}