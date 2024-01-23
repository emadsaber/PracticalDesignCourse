namespace Lab16_Bridge.Solution;

public interface IColor
{
    string Name { get; set; }
}

public class Red : IColor
{
    public Red()
    {
        Name = "Red";
    }

    public string Name { get; set; }
}

public class Blue : IColor
{
    public Blue()
    {
        Name = "Blue";
    }

    public string Name { get; set; }
}

public interface IMaterial
{
    string Name { get; set; }
}

public class Metal : IMaterial
{
    public Metal()
    {
        Name = "Metal";
    }

    public string Name { get; set; }
}

public class Plastic : IMaterial
{
    public Plastic()
    {
        Name = "Plastic";
    }

    public string Name { get; set; }
}

public interface Shape
{
    string Name { get; set; }

    IColor Color { get; set; }

    
    IMaterial Material { get; set; }
}

class Circle : Shape
{
    public string Name { get; set; }

    public IColor Color { get; set; }

    public IMaterial Material { get; set; }
}

class Square : Shape
{
    public string Name { get; set; }

    public IColor Color { get; set; }

    public IMaterial Material { get; set; }
}

class Application
{
    public void Test()
    {
        var c = new Circle();
        c.Name = "Circle 1";
        c.Material = new Plastic();
        c.Color = new Red();

        PrintShape(c);

        var s = new Square();
        s.Name = "Square 1";
        s.Material = new Metal();
        s.Color = new Blue();

        PrintShape(s);
    }

    public void PrintShape(Shape s)
    {
        var sb = new System.Text.StringBuilder();
        sb.Append($"Name: [{s.Name}] ");
        sb.Append($"Color: [{s.Color.Name}] ");
        sb.Append($"Material: [{s.Material.Name}] ");

        Console.WriteLine(sb.ToString());
    }
}
