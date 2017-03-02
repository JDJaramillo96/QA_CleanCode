//Tile class -----------------------------------------------------------------------------------------
public class Tile
{
    private int position = new int[2];
    private Tile[] tiles = new Tile[4] //index 0 = up, index 1 = down, index 2 = right, index 3 = left

    public void SetTile (int tileIndex, Tile tile)
    {
        tiles[tileIndex] = tile;
    }

    public bool CheckUpTile ()
    {
        return tiles[0] != null;
    }

    public Tile GetUpTile ()
    {
        return tiles[0];
    }
}

//TileMap class -----------------------------------------------------------------------------------------
public class TileMap
{
    private Tile [][] tiles;
    
    int width;
    int height;
    int connections;
    
    public TileMap (int width, int height, int connections)
    {
        this.width = width;
        this.height = height;
        this.connections = connections;
        
        SetTileMap();
        
        int dx = 1;
        int dy = 0;

        CheckConnections(dx, dy);
    }

    public void SetTileMap()
    {
        tiles = new Tile[width][height];
        
        for (int i=0; i<width; i++)
        {
            for (int j=0; i<height; j++)
            {
                tiles[i][j] = new Tile (i, j);
            }
        }
    }

    public void CheckConnections(int dx, int dy)
    {
        for (int i=0; i<connections; i++)
        {
            int x = Random.Range (0, width-1);
            int y = Random.Range (0, height-1);
            
            Tile initial = tiles[x, y];
            Tile tile = tiles[x+dx, y+dy];
            
            if (dx == 1)
                initial.Right (tile);
            else if (dy == 1)
                initial.Up (tile);
            
            if (dx == 0)
                dx = 1;
            else
                dx = 0;
            
            if (dy == 0)
                dy = 1;
            else
                dy = 0;
        }
    }

    public Tile GetTile (int x, int y)
    {
        return tiles[x, y];
    }
}

//Player class -----------------------------------------------------------------------------------------
public class Player
{
    private int[] position = new int[2];
    private TileMap map;

    public void TryMove (Direction direction)
    {
        Tile tile = map.GetTile (position[0], position[1]);
        
        switch (direction)
        {
            case Direction.Right:
                if (tile.CheckCanMove ())
                    position[0] += 1;
                break;
            case Direction.Left:
                if (tile.CheckCanMove ())
                    position[0] -= 1;
                break;
            case Direction.Up:
                if (tile.CheckCanMove ())
                    position[1] += 1;
                break;
            case Direction.Down:
                if (tile.CheckCanMove ())
                    position[1] -= 1;
                break;
        }
    }
}

//Direction enum -----------------------------------------------------------------------------------------
public enum Direction
{
    Left,
    Right,
    Up,
    Down
}
