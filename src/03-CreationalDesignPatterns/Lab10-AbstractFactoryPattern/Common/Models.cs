namespace AbstractFactory.Models;

public interface Chair
{
    public double Height { get; set; }
    public double Width { get; set; }
}

public interface Table
{
    public double Diameter { get; set; }
    public double Height { get; set; }
}

public interface Spoon
{
    public double Length { get; set; }
    public double Weight { get; set; }
}



public class WoodChair : Chair
{
    public WoodChair(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public double Height { get; set; }
    public double Width { set; get; }

    public override string ToString()
    {
        return $"I'm a WoodChair with width {Width} and height {Height}";
    }
}

public class PlasticChair : Chair
{
    public PlasticChair(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public double Height { get; set; }
    public double Width { set; get; }

    public override string ToString()
    {
        return $"I'm a PlasticChair with width {Width} and height {Height}";
    }
}

public class WoodTable : Table
{
    public WoodTable(double height, double diameter)
    {
        Height = height;
        Diameter = diameter;
    }
    public double Diameter { get; set; }
    public double Height { get; set; }

    public override string ToString()
    {
        return $"I'm a WoodTable with diameter {Diameter} and height {Height}";
    }
}

public class PlasticTable : Table
{
    public PlasticTable(double height, double diameter)
    {
        Height = height;
        Diameter = diameter;
    }
    public double Diameter { get; set; }
    public double Height { get; set; }

    public override string ToString()
    {
        return $"I'm a PlasticTable with diameter {Diameter} and height {Height}";
    }
}

public class WoodSpoon : Spoon
{
    public WoodSpoon(double length, double weight)
    {
        Length = length;
        Weight = weight;
    }
    public double Length { get; set; }
    public double Weight { get; set; }

    public override string ToString()
    {
        return $"I'm a WoodSpoon with length {Length} and weight {Weight}";
    }
}

public class PlasticSpoon : Spoon
{
    public PlasticSpoon(double length, double weight)
    {
        Length = length;
        Weight = weight;
    }
    public double Length { get; set; }
    public double Weight { get; set; }

    public override string ToString()
    {
        return $"I'm a PlasticSpoon with length {Length} and weight {Weight}";
    }
}
