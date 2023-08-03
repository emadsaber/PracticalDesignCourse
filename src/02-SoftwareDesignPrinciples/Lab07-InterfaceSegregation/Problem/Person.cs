namespace Lab07_InterfaceSegregation.Problem;

#region contract
interface IPerson
{
    public DateTime? HireDate { get; init; }
    void Eat();
    void Walk();
    void Speak();
    void DoWork();
    void Resign();
}
#endregion interface


class Person : IPerson
{
    #region ctor
    public Person(string name, DateTime? hireDate)
    {
        Name = name;
        HireDate = hireDate;
    }
    #endregion

    #region  props

    public string Name { get; init; }
    public DateTime? HireDate { get; init; }

    #endregion

    #region IPerson interface
    public void DoWork()
    {
        Console.WriteLine($"{Name} | Let's do our job perfectly!...");
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} | OMG, so delicious food!...");
    }

    public void Resign()
    {
        Console.WriteLine($"{Name} | Dear Boss, I can't afford it anymore, Good Bye!...");
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} | Hello, and I'm happy...");
    }

    public void Walk()
    {
        Console.WriteLine($"{Name} | It's good weather for walking...");
    }
    #endregion
}
