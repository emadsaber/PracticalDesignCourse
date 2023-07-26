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
    public Cat(string name)
        : base(name)
    {
        //silence is great
    }
}

class BengalCat : Cat
{
    public BengalCat(string name)
        : base(name)
    {
        //silence is great
    }
}


class Feeder
{
    public void Feed(Cat c)
    {
        Console.WriteLine($"Feeding cat {c.Name}");
    }
}

class ChildFeeder : Feeder
{
    public void Feed(Animal a) //here we used a more abstract type than Cat, Liskov substitution is OK
    {
        Console.WriteLine($"Feeding animal {a.Name}");
    }
}

class IncorrectChildFeeder : Feeder
{
    public void Feed(BengalCat a) //here we used a strict type than Cat, Liskov substitution broken
    {
        Console.WriteLine($"Feeding BengalCat {a.Name}");
    }
}

class Program
{
    public static void Main()
    {
        var animal = new Animal("Puppy");
        var cat = new Cat("Kitty");
        var bengalCat = new BengalCat("Bengal Kitten");
        var feeder = new Feeder();
        var childFeeder = new ChildFeeder();
        var incorrectChildFeeder = new IncorrectChildFeeder();

        feeder.Feed(cat);
        feeder.Feed(bengalCat);
        //feeder.Feed(animal); //Error CS1503: Cannot convert from Animal to Cat

        //ChildFeeder can feed all animals
        childFeeder.Feed(animal);
        childFeeder.Feed(cat);
        childFeeder.Feed(bengalCat);

        //incorrectChildFeeder.Feed(animal); //Error CS1503: Cannot convert from Animal to BengalCat
        incorrectChildFeeder.Feed(bengalCat);
    }
}
