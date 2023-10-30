using System;

public interface IShape
{
    void DisplayType();
    void DisplayArea();
    double Size { get; set; }
}

public interface IColoredShape : IShape
{
    string Color { get; set; }
    void DisplayColor();
}

public class Circle : IShape
{
    public Circle(double size)
    {
        Size = size;
    }

    public double Size { get; set; }

    public void DisplayType()
    {
        Console.WriteLine("Це коло");
    }

    public void DisplayArea()
    {
        double area = Math.PI * Size * Size;
        Console.WriteLine($"Площа кола: {area}");
    }
}

public class ColoredCircle : IColoredShape
{
    public ColoredCircle(double size, string color)
    {
        Size = size;
        Color = color;
    }

    public double Size { get; set; }
    public string Color { get; set; }

    public void DisplayType()
    {
        Console.WriteLine("Це коло");
    }

    public void DisplayArea()
    {
        double area = Math.PI * Size * Size;
        Console.WriteLine($"Площа кола: {area}");
    }

    public void DisplayColor()
    {
        Console.WriteLine($"Колір кола: {Color}");
    }
}

class Program
{
    static void Main()
    {
        IShape[] shapes = new IShape[]
        {
            new Circle(5.0),
            new ColoredCircle(3.0, "червоний"),
            new Circle(7.5),
            new ColoredCircle(4.0, "синій"),
            new ColoredCircle(6.0, "зелений")
        };

        foreach (var shape in shapes)
        {
            shape.DisplayType();
            shape.DisplayArea();

            if (shape is IColoredShape coloredShape)
            {
                coloredShape.DisplayColor();
            }

            Console.WriteLine();
        }
    }
}
