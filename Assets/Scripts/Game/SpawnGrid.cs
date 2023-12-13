using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    [SerializeField] private Transform _gridStartPosition;
    [SerializeField] private Transform _bossPosition;
    [SerializeField] private int _columns;
    [SerializeField] private int _rows;

    private SpawnTile[,] _smallEnemyTiles;
    private SpawnTile[,] _mediumEnemyTiles;
    private SpawnTile[,] _largeEnemyTiles;       

    public int MaxCapacity => _smallEnemyTiles.Length;

    private void Awake()
    {
        Initialize();
    }

    public void Clear()
    {
        ClearTiles(_largeEnemyTiles);
        ClearTiles(_mediumEnemyTiles);
        ClearTiles(_smallEnemyTiles);
    }

    public SpawnTile GetBossPlace()
    {
        Vector2 position = new Vector2(_bossPosition.position.x, _bossPosition.position.z);
        return new SpawnTile(0,0, position);
    }

    public SpawnTile GetSmallTile()
    {
        return GetFreeTile(_smallEnemyTiles);
    }

    public SpawnTile GetMediumTile()
    {
        return GetFreeTile(_mediumEnemyTiles);
    }

    public SpawnTile GetLargeTile()
    {
        return GetFreeTile(_largeEnemyTiles);
    }

    private void Initialize()
    {
        Vector2 sizeOffcet = new Vector2(0.5f, 0.5f);
        Vector2 startPosition = new Vector2(_gridStartPosition.position.x, _gridStartPosition.position.z);
        _smallEnemyTiles = GetSubTiles(startPosition);
        startPosition += sizeOffcet;
        _mediumEnemyTiles = GetSubTiles(startPosition, _smallEnemyTiles);
        startPosition += sizeOffcet;
        _largeEnemyTiles = GetSubTiles(startPosition, _mediumEnemyTiles);
    }

    private SpawnTile[,] GetSubTiles(Vector2 startPoint, SpawnTile[,] subTiles = null) 
    {
        SpawnTile[,] spawnTiles;

        if (subTiles == null)
            spawnTiles = new SpawnTile[_columns,_rows];
        else
            spawnTiles = new SpawnTile[subTiles.GetLength(0) - 1, subTiles.GetLength(1) - 1];
                
        int rows = spawnTiles.GetLength(0);
        int columns = spawnTiles.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                spawnTiles[i, j] = new SpawnTile(i, j, startPoint, subTiles);
            }
        }
        return spawnTiles;
    }    

    private SpawnTile GetFreeTile(SpawnTile[,] spawnTiles)
    {
        int rows = spawnTiles.GetLength(0);
        int columns = spawnTiles.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (spawnTiles[i,j].IsEmpty)
                {
                    spawnTiles[i, j].Fill();
                    return spawnTiles[i, j];
                }
            }             
        }

        return null;
    }

    private void ClearTiles(SpawnTile[,] spawnTiles)
    {
        foreach (SpawnTile tile in spawnTiles)
        {
            tile.Clear();
        }
    }
}
