public interface IRenderer
{
    string WhatToRenderAs { get; }
}

public abstract class Shape
{
    private IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return $"Drawing {Name} as {renderer.WhatToRenderAs}";
    }
}

public class Triangle : Shape
{
    public Triangle(IRenderer renderer)
        : base(renderer)
    {
        Name = "Triangle";
    }
}

public class Square : Shape
{
    public Square(IRenderer renderer)
        : base(renderer)
    {
        Name = "Square";
    }
}

public class RasterRender : IRenderer
{
    public string WhatToRenderAs => "pixels";
}

public class VectorRender : IRenderer
{
    public string WhatToRenderAs => "lines";
}

public class Program
{
    static void Main()
    {
        var vectorSquare = new Square(new VectorRender());
        var rasterTriangle = new Triangle(new RasterRender());
        Console.WriteLine(vectorSquare.ToString());
        Console.WriteLine(rasterTriangle.ToString());
    }
}