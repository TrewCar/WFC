class Tile
{
    public Tile(Color[,] Tile)
    {
        Map = Tile;
        CreateGridMap(Tile);
    }
    public Tile(Color[,] Tile, Color[] Upn, Color[] Rightn, Color[] Downn, Color[] Leftn)
    {
        Map = Tile;
        CreateGridMap(Tile);
        this.Leftn = Leftn;
        this.Rightn = Rightn;
        this.Upn = Upn;
        this.Downn = Downn;
    }
    public Color[,] Map { get; private set; }

    public Color[] Left { get; private set; }
    public Color[] Right { get; private set; }
    public Color[] Up { get; private set; }
    public Color[] Down { get; private set; }

    public Color[] Leftn { get; private set; }
    public Color[] Rightn { get; private set; }
    public Color[] Upn { get; private set; }
    public Color[] Downn { get; private set; }

    private void CreateGridMap(Color[,] Tile)
    {
        Up = new Color[Tile.GetLength(0)];
        Down = new Color[Tile.GetLength(0)];
        Left = new Color[Tile.GetLength(0)];
        Right = new Color[Tile.GetLength(0)];

        for (int i = 0; i < Tile.GetLength(0); i++)
        {
            Up[i] = Tile[i, 0];
        }
        for (int i = 0; i < Tile.GetLength(0); i++)
        {
            Down[i] = Tile[i, 1];
        }
        for (int i = 0; i < Tile.GetLength(0); i++)
        {
            Left[i] = Tile[0, i];
        }
        for (int i = 0; i < Tile.GetLength(0); i++)
        {
            Right[i] = Tile[1, i];
        }
    }

    public void Draw(Point pos, Graphics g)
    {
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                g.FillRectangle(new SolidBrush(Map[i, j]), pos.X * Settings.RectSZ + Settings.RectSZ/Settings.Cells * i, pos.Y * Settings.RectSZ + Settings.RectSZ / Settings.Cells * j, Settings.RectSZ / Settings.Cells, Settings.RectSZ / Settings.Cells);
            }
        }
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

    public Color[,] CloneMap()
    {
        return (Color[,])Map.Clone();
    }
}
