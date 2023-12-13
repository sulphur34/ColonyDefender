using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnTile
{
    private List<SpawnTile> _subTiles;
    private bool _isEmpty;

    public int Row { get; private set; }
    public int Column { get; private set; }
    public Vector2 SpawnPosition { get; private set; }
    public bool IsEmpty => _isEmpty && IsSubtilesEmpty();

    public SpawnTile(int row, int column, Vector2 startPoint, SpawnTile[,] subTiles = null)
    {
        Row = row;
        Column = column;
        _isEmpty = true;
        SpawnPosition = new Vector2(startPoint.x + Row, startPoint.y + Column);
        _subTiles = GetSubTiles(subTiles);
    }

    public void Fill()
    {
        if (_subTiles !=  null)
        {
            foreach (SpawnTile adjacentTile in _subTiles)
                adjacentTile.Fill();
        }

        _isEmpty = false;
    }

    public void Clear()
    {
        _isEmpty = true;

        if (_subTiles != null)
        {
            foreach (SpawnTile adjacentTile in _subTiles)
                adjacentTile.Clear();
        }
    }

    private List<SpawnTile> GetSubTiles(SpawnTile[,] subTiles)
    {
        if (subTiles == null)
            return null;    
        
        List<SpawnTile> adjacentTiles = new List<SpawnTile>(4);

        for (int i = 0; i <= 1; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                adjacentTiles.Add(subTiles[i + Row, j + Column]);
            }
        }

        return adjacentTiles;
    }

    private bool IsSubtilesEmpty()
    {
        if (_subTiles == null)
            return true;
        else
        {
            return _subTiles.All(tile => tile.IsEmpty);
        }
    }
}
