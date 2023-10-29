namespace FactoryMethod.Porblem;
abstract class Pizza {
    public string Name { get; protected set; }
    public List<string> Toppings { get; protected set; }
    public void GetPrice(){
        var price =Toppings == null ? 50M : Toppings.Count * 30M;
        
        Console.WriteLine($"Total Price will be: {price}");
    }

    public void Prepare()
    {
        Console.WriteLine("Preparing " + Name);
        Console.WriteLine("Adding toppings:");

        foreach(string topping in Toppings)
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

class CheesePizza : Pizza{
    public CheesePizza()
    {
        Name = "Cheese Pizza";
        Toppings = new List<string>{
            "Cheese",
            "Mozzarilla",
            "Cheddar",
        };
    }
}

class PepproniPizza : Pizza{
    public PepproniPizza()
    {
        Name = "Pepproni Pizza";
        Toppings = new List<string>{
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

class VegetablePizza : Pizza{
    public VegetablePizza()
    {
        Name = "Vegetable Pizza";
        Toppings = new List<string>{
            "Olive Slices",
            "Green pepper",
        };
    }
}

class PizzaStore
{
    public Pizza OrderPizza(string type) { 
        Pizza pizza = null;

        //here is the problem:
        //1- if we want to add a new pizza type, we should make a modification here
        //2- This code doesn't respect OCP, because it's not closed for modification and there is another code for preparing pizza
        //3- If we need to add another Pizza Store, this code will get more complicated
        //We should take a step to move Pizza object initialization to a separate object called : Factory
        if(type == "cheese"){
            pizza = new CheesePizza();
        }
        else if(type == "pepproni"){
            pizza = new PepproniPizza();
        }
        else if(type == "vegetable"){
            pizza = new VegetablePizza();
        }

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        pizza.GetPrice();
        return pizza;
    }
}
