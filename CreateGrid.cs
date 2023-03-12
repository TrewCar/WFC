static class CreateGrid
{
    static public List<Tile> CreateGri(Bitmap input)
    {
        CreateTile(input);
        
        return Tiles;
    }
    static private readonly int RectSZ = 10;
    static private int Cells = 2;
    static private Graphics g;

    static private List<Tile> Tiles = new();
    static private void CreateTile(Bitmap input)
    {
        for (int i = 0; i < input.Width; i += RectSZ)
        {
            for (int j = 0; j < input.Height; j += RectSZ)
            {
                Color[,] map = new Color[2, 2];

                for (int t = 0; t < 2; t++)
                {
                    for (int r = 0; r < 2; r++)
                    {
                        Point temp = new(i  + t * RectSZ / 2, j + r * RectSZ / 2);
                        ProvPos(ref temp, 0, input.Width);
                        map[t, r] = input.GetPixel(temp.X, temp.Y);
                    }
                }

                Color[] LeftNeighbour = new Color[2];
                Color[] UpNeighbour = new Color[2];
                Color[] RightNeighbour = new Color[2];
                Color[] DownNeighbour = new Color[2];

                for (int t = 0; t < 2; t++)
                {
                    var temp = Left[t];
                    temp = new Point(i  + temp.X * RectSZ / 2, j + temp.Y * RectSZ / 2);
                    ProvPos(ref temp, 0, input.Width);
                    LeftNeighbour[t] = input.GetPixel(temp.X, temp.Y);
                }
                for (int t = 0; t < 2; t++)
                {
                    var temp = Up[t];
                    temp = new Point(i + temp.X * RectSZ / Cells, j + temp.Y * RectSZ / Cells);
                    ProvPos(ref temp, 0, input.Width);
                    UpNeighbour[t] = input.GetPixel(temp.X, temp.Y);
                }
                for (int t = 0; t < 2; t++)
                {
                    var temp = Right[t];
                    temp = new Point(i + temp.X * RectSZ / Cells, j + temp.Y * RectSZ / Cells);
                    ProvPos(ref temp, 0, input.Width);
                    RightNeighbour[t] = input.GetPixel(temp.X, temp.Y);
                }
                for (int t = 0; t < 2; t++)
                {
                    var temp = Down[t];
                    temp = new Point(i + temp.X * RectSZ / Cells, j + temp.Y * RectSZ / Cells);
                    ProvPos(ref temp, 0, input.Width);
                    DownNeighbour[t] = input.GetPixel(temp.X, temp.Y);
                }

                bool q = true;
                
                for (int t = 0; t < Tiles.Count; t++)
                {
                    if (Tiles[t] == map)
                    {
                        Tiles[t].AddNeighbour(Neighbour.Up, UpNeighbour);
                        Tiles[t].AddNeighbour(Neighbour.Down, DownNeighbour);
                        Tiles[t].AddNeighbour(Neighbour.Left, LeftNeighbour);
                        Tiles[t].AddNeighbour(Neighbour.Right, RightNeighbour);

                        q = false;
                        break;
                    }
                }
                
                if (q) Tiles.Add(new Tile(map, LeftNeighbour, RightNeighbour, UpNeighbour, DownNeighbour));
            }
        }
        
    }
    static private void ProvPos(ref Point Pos, int Min, int Max)
    {
        if (Pos.X == Max)
            Pos.X = 0;
        else if (Pos.X < Min)
            Pos.X = Max - 5;

        if (Pos.Y == Max)
            Pos.Y = 0;
        else if (Pos.Y < Min)
            Pos.Y = Max - 5;
    }

    #region Pos Next Neighbour //DON'T TOUCH
    static private readonly Point[] Left = new Point[2]
    {
        new Point(-1,0),
        new Point(-1,1)
    };
    static private readonly Point[] Right = new Point[2]
    {
        new Point(2,0),
        new Point(2,1)
    };
    static private readonly Point[] Down = new Point[2]
    {
        new Point(0,2),
        new Point(1,2)
    };
    static private readonly Point[] Up = new Point[2]
    {
        new Point(0,-1),
        new Point(1,-1)
    };
    #endregion
}