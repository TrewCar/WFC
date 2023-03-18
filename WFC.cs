class WFC
{
    public WFC(List<Tile> Tiles, int Widht, int Height)
    {
        this.Tiles = Tiles;
        pictureOutput = new Bitmap(Widht, Height);
        Grid = new Tile[Widht / RectSZ, Height / RectSZ];
    }
    private List<Tile> Tiles;
    private int RectSZ = Settings.RectSZ;

    private Bitmap pictureOutput;
    private Tile[,] Grid;
    Graphics g;
    public Bitmap CreateIMG()
    {
        g = Graphics.FromImage(pictureOutput);
        Random rand = new Random();
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                if (j - 1 < 0 && i - 1 < 0)
                {
                    Draw(Tiles, new Point(i, j));
                }
                else if (j - 1 < 0 && i - 1 >= 0)
                {
                    Point pos = new Point(i, j);
                    List<Tile> temp = Tiles.Where(x => ContainsList(x.Leftn, Grid[i - 1, j].Right) /*|| ContainsList(x.Left, Grid[i - 1, j].Right)*/).ToList();
                    Draw(temp, pos);
                }
                else if(j -1 >= 0 && i -1<0)
                {
                    Point pos = new Point(i, j);
                    List<Tile> temp = Tiles.Where(x => ContainsList(x.Upn, Grid[i, j - 1].Down)/* || ContainsList(x.Up, Grid[i, j - 1].Down)*/).ToList();
                    Draw(temp, pos);
                }
                else
                {
                    Point pos = new Point(i, j);
                    List<Tile> temp = Tiles.Where(x => ContainsList(x.Leftn, Grid[i - 1, j].Right) && ContainsList(x.Upn, Grid[i, j - 1].Down)/* || ContainsList(x.Left, Grid[i - 1, j].Right) && ContainsList(x.Up, Grid[i, j - 1].Down)*/).ToList();
                    Draw(temp, pos);
                }
            }
        }
        return pictureOutput;
    }
    private void Draw(List<Tile> tiles, Point pos)
    {
        Random rand = new Random();
        if (tiles.Count == 0)
        {
            int t = rand.Next(Tiles.Count);
            Tiles[t].Draw(new Point(pos.X, pos.Y), g);
            Grid[pos.X, pos.Y] = Tiles[t];
            return;
        }      
        int temp = rand.Next(tiles.Count);
        tiles[temp].Draw(new Point(pos.X, pos.Y), g);
        Grid[pos.X, pos.Y] = tiles[temp];
    }
    private bool ContainsList(Color[] color, Color[] Nidet)
    {
        for (int i = 0; i < color.Length; i++)
        {
            if(!(Nidet[i] == color[i]))
                return false;
        }
        return true;
    }
}

