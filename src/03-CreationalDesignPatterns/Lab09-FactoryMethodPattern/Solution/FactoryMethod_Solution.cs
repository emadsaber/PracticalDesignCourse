namespace FactoryMethod.Solution;

abstract class Pizza
{
    public string Name { get; protected set; }
    public List<string> Toppings { get; protected set; }

    public void GetPrice()
    {
        var price = Toppings == null ? 50M : Toppings.Count * 30M;

        Console.WriteLine($"Total Price will be: {price}");
    }

    public void Prepare()
    {
        Console.WriteLine("Preparing " + Name);
        Console.WriteLine("Adding toppings:");

        foreach (string topping in Toppings)
        {
            Console.WriteLine("\t" + topping);
        }
    }

    public virtual void Bake()
    {
        Console.WriteLine("Bake for 25 minutes at 350");
    }

    public virtual void Cut()
    {
        Console.WriteLine("Cutting the pizza into diagonal slices");
    }

    public virtual void Box()
    {
        Console.WriteLine("Place pizza in official PizzaStore box");
    }
}

class CheesePizza : Pizza
{
    public CheesePizza()
    {
        Name = "Cheese Pizza";
        Toppings = new List<string> { "Cheese", "Mozzarilla", "Cheddar", };
    }
}

class PepproniPizza : Pizza
{
    public PepproniPizza()
    {
        Name = "Pepproni Pizza";
        Toppings = new List<string>
        {
            "Cheese",
            "Pepproni",
            "Olive Slices",
            "Green pepper"
        };
    }

    public override void Bake()
    {
        Console.WriteLine("Bake for 30 minutes at 400");
    }
}

class VegetablePizza : Pizza
{
    public VegetablePizza()
    {
        Name = "Vegetable Pizza";
        Toppings = new List<string> { "Olive Slices", "Green pepper", };
    }
}


class CheesePizzaKitchen : Kitchen
{
    //Respects SRP
    protected override Pizza CreatePizza()//This is a factory method
    {
        return new CheesePizza();
    }
}
class PepproniPizzaKitchen : Kitchen
{
    //Respects SRP
    protected override Pizza CreatePizza()//This is a factory method
    {
        return new PepproniPizza();
    }
}
class VegetablePizzaKitchen : Kitchen
{
    //Respects SRP
    protected override Pizza CreatePizza()//This is a factory method
    {
        return new VegetablePizza();
    }
}

abstract class Kitchen //marked as abstract to prohibit clients of instantiation
{
    public Pizza GetPizza()
    {
        Pizza pizza = null;

        pizza = CreatePizza(); //Initialization code splitted to each store type

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        pizza.GetPrice();

        return pizza;
    }

    protected abstract Pizza CreatePizza();
}
