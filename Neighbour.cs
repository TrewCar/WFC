using System.Collections;

public enum Neighbour
{
    Left,
    Right,
    Up,
    Down
}
public class MyComparer : IEqualityComparer<Color[]>
{
    public bool Equals(Color[] x, Color[] y)
    {
        if (x[0] == y[0] && x[1] == y[1])
            return true;
        else
            return false;
    }

    public int GetHashCode(Color[] obj)
    {
        return 0;
    }
}

static public class Settings
{
    public static readonly int RectSZ = 10;
    public static readonly int Cells = 2;
}