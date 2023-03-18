static class CreateGrid
{
    static public List<Tile> CreateTile(Bitmap input)
    {
        Tiles = new();
        CreateTiles(input);



        return Tiles;
    }
    static Color[,] Rotate90(Color[,] oldMatrix)
    {
        Color[,] newMatrix = new Color[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newColumn, newRow = 0;
        for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
        {
            newColumn = 0;
            for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
            {
                newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                newColumn++;
            }
            newRow++;
        }
        return newMatrix;
    }


    static private readonly int RectSZ = Settings.RectSZ;
    static private int Cells = Settings.Cells;

    static private List<Tile> Tiles = new();
    static private void CreateTiles(Bitmap input)
    {
        for (int i = 0; i < input.Width; i += RectSZ / Cells)
        {
            for (int j = 0; j < input.Height; j += RectSZ / Cells)
            {
                Color[,] map = new Color[Cells, Cells];
                try
                {
                    for (int t = 0; t < Cells; t++)
                    {
                        for (int r = 0; r < Cells; r++)
                        {
                            Point temp = new(i + t * RectSZ / Cells, j + r * RectSZ / Cells);
                            map[t, r] = input.GetPixel(temp.X, temp.Y);
                        }
                    }
                }
                catch
                {
                    break;
                }

                Point UpN = new Point(0, j - RectSZ / Cells);
                Color[] Upn = new Color[Cells];
                ProvPos(ref UpN, 0, input.Width);
                for (int t = 0; t < Cells; t++)
                {
                    Upn[t] = input.GetPixel(i + t * RectSZ / Cells, UpN.Y);
                }

                Point DownN = new Point(0, j + RectSZ);
                Color[] Downn = new Color[Cells];
                ProvPos(ref DownN, 0, input.Width);
                for (int t = 0; t < Cells; t++)
                {
                    Downn[t] = input.GetPixel(i + t * RectSZ / Cells, DownN.Y );
                }

                Point LeftN = new Point(i - RectSZ / Cells, 0);
                Color[] Leftn = new Color[Cells];
                ProvPos(ref LeftN, 0, input.Width);
                for (int t = 0; t < Cells; t++)
                {
                    Leftn[t] = input.GetPixel(LeftN.X, j + t * RectSZ / Cells);
                }

                Point RightN = new Point(i + RectSZ, 0);
                Color[] Rightn = new Color[Cells];
                ProvPos(ref RightN, 0, input.Width);
                for (int t = 0; t < Cells; t++)
                {
                    Rightn[t] = input.GetPixel(RightN.X, j + t * RectSZ / Cells);
                }

                Tiles.Add(new Tile(map, Upn, Rightn, Downn, Leftn));
                
                var t1 = Rotate90(map);
                Tiles.Add(new Tile(t1, Leftn.Reverse().ToArray(), Upn, Rightn.Reverse().ToArray(), Downn));
                var t2 = Rotate90(t1);
                Tiles.Add(new Tile(t2, Downn.Reverse().ToArray(), Leftn.Reverse().ToArray(), Upn.Reverse().ToArray(), Rightn.Reverse().ToArray()));
                var t3 = Rotate90(t2);
                Tiles.Add(new Tile(t3, Rightn.Reverse().ToArray().Reverse().ToArray(), Downn.Reverse().ToArray(), Leftn.Reverse().ToArray().Reverse().ToArray(), Upn.Reverse().ToArray()));
                
            }
        }
    }
    static private void ProvCop(Color[,] map)
    {
        /*
        bool q = true;
        for (int t = 0; t < Tiles.Count; t++)
        {
            if (Tiles[t] == map)
            {
                q = false;
                break;
            }
        }
        
        if (q) 
        */
        Tiles.Add(new Tile(map));
    }
    static private void ProvPos(ref Point Pos, int Min, int Max)
    {
        if (Pos.X == Max)
            Pos.X = 0;
        else if (Pos.X < Min)
            Pos.X = Max - RectSZ / Cells;

        if (Pos.Y == Max)
            Pos.Y = 0;
        else if (Pos.Y < Min)
            Pos.Y = Max - RectSZ / Cells;
    }
}