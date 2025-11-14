using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Cyan", 3, 9));
        shapes.Add(new Circle("Magenta", 2));
        shapes.Add(new Square("Blue", 8));
        shapes.Add(new Rectangle("Beige", 2, 4));
        shapes.Add(new Circle("Pink", 7));
        shapes.Add(new Square("Yellow", 15));
        shapes.Add(new Rectangle("Green", 9, 12));
        shapes.Add(new Circle("Purple", 21));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine();
        }
        
    }

}