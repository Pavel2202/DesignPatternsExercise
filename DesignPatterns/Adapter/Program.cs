public class Square
{
    public int Side { get; set; }
}

public interface IRectangle
{
    int Width { get; }

    int Height { get; }
}

public static class ExtensionMethods
{
    public static int Area(this IRectangle rc)
    {
        return rc.Width * rc.Height;
    } 
}

public class SquareToRectangeAdapter : IRectangle
{
    private readonly Square square;

    public SquareToRectangeAdapter(Square square)
    {
        this.square = square;
    }

    public int Width => square.Side;
    public int Height => square.Side;
}

public class Program
{
    static void Main()
    {
        var sq = new Square { Side = 8 };
        var adapter = new SquareToRectangeAdapter(sq);
        Console.WriteLine(adapter.Area());
    }
}