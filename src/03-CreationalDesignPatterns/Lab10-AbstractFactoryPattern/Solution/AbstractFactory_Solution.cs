using AbstractFactory.Models;

namespace AbstractFactory.Solution;

public interface ProductAbstractFactory
{
    Chair CreateChair(double height, double width);
    Table CreateTable(double height, double diameter);
    Spoon CreateSpoon(double length, double weight);
}

public class PlasticFactory : ProductAbstractFactory
{
    public Spoon CreateSpoon(double length, double weight)
    {
        return new PlasticSpoon(length, weight);
    }

    public Chair CreateChair(double height, double width)
    {
        return new PlasticChair(height, width);
    }

    public Table CreateTable(double height, double diameter)
    {
        return new PlasticTable(height, diameter);
    }
}

public class WoodFactory : ProductAbstractFactory
{
    public Spoon CreateSpoon(double length, double weight)
    {
        return new WoodSpoon(length, weight);
    }

    public Chair CreateChair(double height, double width)
    {
        return new WoodChair(height, width);
    }

    public Table CreateTable(double height, double diameter)
    {
        return new WoodTable(height, diameter);
    }
}

public class Application
{
    private ProductAbstractFactory _productFactory;

    public Application()
    {
        ReadApplicationConfigFile();
    }

    public void ProduceBatch(){
        var chair = _productFactory.CreateChair(110, 40);
        var table = _productFactory.CreateTable(100, 110);
        var spoon = _productFactory.CreateSpoon(12, 30);

        Console.WriteLine(chair);
        Console.WriteLine(table);
        Console.WriteLine(spoon);
    }

    private void ReadApplicationConfigFile()
    {
        Console.WriteLine("Enter the material type:");
        
        var material = Console.ReadLine();

        if (material.ToLower() == "wood")
            _productFactory = new WoodFactory();
        else if (material.ToLower() == "plastic")
            _productFactory = new PlasticFactory();
        else
            throw new Exception("Invalid material type");
    }
}
