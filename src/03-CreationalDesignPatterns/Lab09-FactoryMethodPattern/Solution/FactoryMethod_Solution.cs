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

class MexicanCheesePizza : Pizza
{
    public MexicanCheesePizza()
    {
        Name = "Mexican Cheese Pizza";
        Toppings = new List<string> { "Mexican Cheese", "Mozzarilla", "Cheddar", };
    }
}

class ItalianCheesePizza : Pizza
{
    public ItalianCheesePizza()
    {
        Name = "Italian Cheese Pizza";
        Toppings = new List<string> { "Italian Cheese", "Cheddar", };
    }
}

class MexicanPepproniPizza : Pizza
{
    public MexicanPepproniPizza()
    {
        Name = "Mexican Pepproni Pizza";
        Toppings = new List<string>
        {
            "Mexican Cheese",
            "Pepproni",
            "Olive Slices",
            "Green pepper"
        };
    }

    public override void Bake()
    {
        Console.WriteLine("Bake for 35 minutes at 450");
    }
}

class ItalianPepproniPizza : Pizza
{
    public ItalianPepproniPizza()
    {
        Name = "Italian Pepproni Pizza";
        Toppings = new List<string>
        {
            "Italian Cheese",
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

class MexicanVegetablePizza : Pizza
{
    public MexicanVegetablePizza()
    {
        Name = "Mexican Vegetable Pizza";
        Toppings = new List<string> { "Mexican Olive Slices", "Green pepper", };
    }
}

class ItalianVegetablePizza : Pizza
{
    public ItalianVegetablePizza()
    {
        Name = "Vegetable Pizza";
        Toppings = new List<string> { "ItalianOlive Slices", "Green pepper", };
    }
}

class MexicanPizzaStore : PizzaStore
{
    //Respects SRP
    protected override Pizza CreatePizza(string type)//This is a factory method
    {
        Pizza pizza = null;

        if (type == "cheese")
        {
            pizza = new MexicanCheesePizza();
        }
        else if (type == "pepproni")
        {
            pizza = new MexicanPepproniPizza();
        }
        else if (type == "vegetable")
        {
            pizza = new MexicanVegetablePizza();
        }
        return pizza;
    }
}

class ItalianPizzaStore : PizzaStore
{
    //Respects SRP
    protected override Pizza CreatePizza(string type)//This is a factory method
    {
        Pizza pizza = null;
        if (type == "cheese")
        {
            pizza = new ItalianCheesePizza();
        }
        else if (type == "pepproni")
        {
            pizza = new ItalianPepproniPizza();
        }
        else if (type == "vegetable")
        {
            pizza = new ItalianVegetablePizza();
        }
        return pizza;
    }
}

abstract class PizzaStore //marked as abstract to prohibit clients of instantiation
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza = null;

        pizza = CreatePizza(type); //Initialization code splitted to each store type

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        pizza.GetPrice();

        return pizza;
    }

    protected abstract Pizza CreatePizza(string type);
}
