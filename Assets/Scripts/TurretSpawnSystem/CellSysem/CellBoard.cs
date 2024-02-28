using System.Collections.Generic;
using TurretSystem;
using UnityEngine;
using Utils.Interfaces;

namespace TurretSpawnSystem.CellSystem
{
    public class CellBoard : MonoBehaviour
    {
        private readonly float _rows = 5;
        private readonly float _columns = 5;

        [SerializeField] private Column[] _cells;
        [SerializeField] private TurretFactory _turretFactory;

        public float MaxTurretLevel { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        public void AddTurret(int columnIndex, float turretLevel)
        {
            if (_cells[columnIndex].TryGetFreeCell(out ICell cell))
            {
                SetMaxTurretLevel(turretLevel);
                Turret turret = _turretFactory.Build(turretLevel);
                turret.transform.position = _cells[cell.Column].SpawnPosition;
                cell.AddTurret(turret);
                TryMerge(cell);
                CollapseAll();
            }
        }

        public void Clear()
        {
            MaxTurretLevel = 0;

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _cells[i][j].RemoveTurret();
                }
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _columns; j++)
                    _cells[i][j].Initialize(j, i);
        }

        private bool TryGetMergeableCells(ICell cell, out List<ICell> mergeableCells)
        {
            mergeableCells = new List<ICell>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (Mathf.Abs(i) != Mathf.Abs(j) &&
                        TryGetCellByPosition(cell.Row + j, cell.Column + i, out ICell adjacentCell))
                    {
                        if (cell.CanMerge(adjacentCell))
                            mergeableCells.Add(adjacentCell);
                    }
                }
            }

            return mergeableCells.Count > 0;
        }

        private bool TryGetCellByPosition(int row, int column, out ICell cell)
        {
            if (row >= 0 && column >= 0 && row < _rows && column < _columns)
            {
                cell = _cells[column][row];
                return true;
            }

            cell = null;
            return false;
        }

        private bool TryMerge(ICell cell)
        {
            if (TryGetMergeableCells(cell, out List<ICell> mergeableCells))
            {
                float mergedTurretLevel = 2 * mergeableCells.Count + (cell.TurretLevel - 1);
                cell.RemoveTurret();

                foreach (ICell mergedCell in mergeableCells)
                    mergedCell.RemoveTurret();

                AddTurret(cell.Column, mergedTurretLevel);
            }

            return false;
        }

        private void CollapseAll()
        {
            foreach (IColumn column in _cells)
            {
                column.Collapse();
            }

            foreach (IColumn column in _cells)
            {
                foreach (ICell cell in column)
                {
                    if (cell.TurretLevel > 0 && TryMerge(cell))
                    {
                        CollapseAll();
                    }
                }
            }
        }

        private void SetMaxTurretLevel(float turretLevel)
        {
            MaxTurretLevel = MaxTurretLevel < turretLevel ? turretLevel : MaxTurretLevel;
        }
    }
}