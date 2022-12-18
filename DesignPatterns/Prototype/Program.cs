public class Point
{
    public int X, Y;
}

public class Line
{
    public Point Start, End;

    public Line DeepCopy()
    {
        var newStart = new Point { X = Start.X, Y = Start.Y };
        var newEnd = new Point { X = End.X, Y = End.Y };
        return new Line { Start = newStart, End = newEnd };
    }

    public override string ToString()
    {
        return $"Start: [{Start.X}, {Start.Y}], End: [{End.X}, {End.Y}]";
    }
}

public class Program
{
    static void Main()
    {
        var line1 = new Line
        { 
            Start = new Point { X = 2, Y = 2 },
            End = new Point { X = 8, Y = 8 } 
        };

        var line2 = line1.DeepCopy();

        Console.WriteLine(line1);
        Console.WriteLine(line2);

        line2.End.X = 10;
        line2.End.Y = 10;

        Console.WriteLine(line1);
        Console.WriteLine(line2);
    }
}