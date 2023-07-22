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
    public void Feed(Animal a)
    {
        Console.WriteLine($"Feeding animal {a.Name}");
    }
}

class Program
{
    public static void Main()
    {
        var dog = new Animal("Puppy");
        var cat = new Cat("Kitty");
        var feeder = new Feeder();
        var childFeeder = new ChildFeeder();

        feeder.Feed(cat);
        //feeder.Feed(dog); Error CS1503: Cannot convert from Animal to Cat
        childFeeder.Feed(dog);
        childFeeder.Feed(cat);
    }
}