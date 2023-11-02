using AbstractFactory.Models;
namespace AbstractFactory.Problem;

class Application
{
    public static string GetProductDetails(
        string type,
        string material,
        double dimension1,
        double dimension2
    )
    {
        if (material == "wood" && type == "chair")
        {
            return new WoodChair(dimension1, dimension2).ToString();
        }
        else if (material == "plastic" && type == "chair")
        {
            return new PlasticChair(dimension1, dimension2).ToString();
        }
        else if (material == "wood" && type == "spoon")
        {
            return new WoodSpoon(dimension1, dimension2).ToString();
        }
        else if (material == "plastic" && type == "spoon")
        {
            return new PlasticSpoon(dimension1, dimension2).ToString();
        }
        else if (material == "wood" && type == "table")
        {
            return new WoodTable(dimension1, dimension2).ToString();
        }
        else if (material == "plastic" && type == "table")
        {
            return new PlasticTable(dimension1, dimension2).ToString();
        }

        throw new ArgumentException($"Invalid parameters {nameof(material)} or {nameof(type)}");
    }
}
