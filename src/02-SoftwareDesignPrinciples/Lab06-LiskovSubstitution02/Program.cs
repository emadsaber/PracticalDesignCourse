class Animal
{
    public string Name { get; set; }
    public Animal(string name)
    {
        Name = name;
    }
}

class Cat : Animal
{
    public Cat(string name):base(name) 
    {
        //silence is great
    }

    public void SayMyType(){
        Console.WriteLine($"Hello, My name is: {Name}!");
    }
}

class BengalCat : Cat
{
    public BengalCat(string name):base("BengalCat: " + name) 
    {
        //silence is great
    }

    
}

class CatFactory
{
    public Cat CreateCat(string name)
    {
        return new Cat(name);
    }
}

class AnotherCatFactory : CatFactory
{
    //We can use BengalCat return type 
    //we used "new" to remove a warning that we are hiding a member of base class
    public new BengalCat CreateCat(string name) 
    {
        return new BengalCat(name);
    }
    
    //but we can't use Animal as return type
    // public new Animal CreateCat(string name) 
    // {
    //     return new BengalCat(name);
    // }
}

class Program
{
    public static void Main()
    {
        var factory = new CatFactory();
        var anotherFactory = new AnotherCatFactory();

        var cat1 = factory.CreateCat("Kitty");
        var cat2 = anotherFactory.CreateCat("Tom");

        Console.WriteLine($"CatFactory create a cat named {cat1.Name}");
        Console.WriteLine($"AnotherCatFactory create a cat named {cat2.Name}");

        cat2.SayMyType();
    }
}