using System.Drawing;

class Tile
{
    public Tile(Color[,] Tile, Color[] Left, Color[] Right, Color[] Up, Color[] Down)
    {
        Map = Tile;
        CreateGridMap(Tile);
        this.LeftNeighbour.Add(Left);
        this.RightNeighbour.Add(Right);
        this.UpNeighbour.Add(Up);
        this.DownNeighbour.Add(Down);
    }
    public Tile(Color[,] Tile, List<Color[]> Left, List<Color[]> Right, List<Color[]> Up, List<Color[]> Down)
    {
        Map = Tile;
        CreateGridMap(Tile);
        LeftNeighbour = Left;
        RightNeighbour = Right;
        UpNeighbour = Up;
        DownNeighbour = Down;
    }
    public Color[,] Map { get; private set; }

    public List<Color[]> LeftNeighbour { get; private set; } = new();
    public List<Color[]> RightNeighbour { get; private set; } = new();
    public List<Color[]> UpNeighbour { get; private set; } = new();
    public List<Color[]> DownNeighbour { get; private set; } = new();

    public Color[] Left { get; private set; }
    public Color[] Right { get; private set; }
    public Color[] Up { get; private set; }
    public Color[] Down { get; private set; }

    private void CreateGridMap(Color[,] Tile)
    {
        Up = new Color[2];
        Down = new Color[2];
        Left = new Color[2];
        Right = new Color[2];

        Up[0] = Tile[0, 0];
        Up[1] = Tile[1, 0];

        Down[0] = Tile[0,1];
        Down[1] = Tile[1, 1];

        Left[0] = Tile[0, 0];
        Left[1] = Tile[0, 1];

        Right[0] = Tile[1, 0];
        Right[1] = Tile[1, 1];

    }

    public void AddNeighbour(Neighbour pos, Color[] Neighbour)
    {
        switch (pos)
        {
            case global::Neighbour.Left:
                LeftNeighbour.Add(Neighbour);
                break;
            case global::Neighbour.Right:
                RightNeighbour.Add(Neighbour);
                break;
            case global::Neighbour.Up:
                UpNeighbour.Add(Neighbour);
                break;
            case global::Neighbour.Down:
                DownNeighbour.Add(Neighbour);
                break;
            default:
                break;
        }
    }
    public void ClearData()
    {
        LeftNeighbour = LeftNeighbour.Distinct(new MyComparer()).ToList();
        RightNeighbour = RightNeighbour.Distinct(new MyComparer()).ToList();
        UpNeighbour = UpNeighbour.Distinct(new MyComparer()).ToList();
        DownNeighbour = DownNeighbour.Distinct(new MyComparer()).ToList();
    }

    public static bool operator ==(Tile one, Color[,] Map)
    {
        if (one.Map.Length != Map.Length)
            return false;

        for (int i = 0; i < one.Map.GetLength(0); i++)
        {
            for (int j = 0; j < one.Map.GetLength(1); j++)
            {
                if (one.Map[i, j] != Map[i, j])
                    return false;
            }
        }

        return true;
    }
    public static bool operator !=(Tile one, Color[,] Map) => !(one == Map);
}
