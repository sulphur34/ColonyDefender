using System.Collections;
using UnityEngine;
using Utils.Interfaces;

namespace TurretSpawnSystem.CellSystem
{
    [System.Serializable]
    public class Column : IEnumerable, IColumn
    {
        [SerializeField] private Cell[] _cells;
        [SerializeField] private Transform _spawnPosition;

        public Vector3 SpawnPosition => _spawnPosition.position;

        public ICell this[int index]
        {
            get
            {
                ICell cell = _cells[index];
                return cell;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (ICell cell in _cells)
            {
                yield return cell;
            }
        }

        public bool TryGetFreeCell(out ICell cell)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                if (_cells[i].TurretLevel != 0)
                    continue;

                cell = _cells[i];
                return true;
            }

            cell = null;
            return false;
        }

        public void Collapse()
        {
            if (TryGetFreeCell(out ICell cell))
            {
                while (cell.Row < _cells.Length - 1 && TryGetNextOccupiedCell(cell, out ICell nextCell))
                {
                    nextCell.PassTurret(cell);
                    cell = nextCell;
                }
            }
        }

        public bool TryGetNextOccupiedCell(ICell cell, out ICell nextCell)
        {
            nextCell = null;

            if (cell.Row + 1 == _cells.Length)
                return false;

            for (int i = cell.Row + 1; i < _cells.Length; i++)
            {
                if (_cells[i].TurretLevel == 0)
                    continue;

                nextCell = _cells[i];
                return true;
            }

            return false;
        }
    }
}