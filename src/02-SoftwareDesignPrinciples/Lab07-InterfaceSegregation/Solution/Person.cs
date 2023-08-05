namespace Lab07_InterfaceSegregation.Solution;

#region contract
interface IPerson
{
    void Eat();
    void Walk();
    void Speak();
}

interface IEmployee
{
    public DateTime? HireDate { get; init; }
    void DoWork();
    void Resign();
}
#endregion interface


class Child : IPerson
{
    #region ctor
    public Child(string name)
    {
        Name = name;
    }
    #endregion

    #region  props
    public string Name { get; init; }
    #endregion

    #region IPerson interface
    public void Eat()
    {
        Console.WriteLine($"{Name} | OMG, so delicious food!...");
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

class Employee : IPerson, IEmployee
{
    #region ctor
    public Employee(string name, DateTime? hireDate)
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
    public void Eat()
    {
        Console.WriteLine($"{Name} | OMG, so delicious food!...");
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

    #region IEmployee interface
    public void DoWork()
    {
        Console.WriteLine($"{Name} | Let's do our job perfectly!...");
    }

    public void Resign()
    {
        Console.WriteLine(
            $"{Name} | Dear Boss, I was hired on {HireDate:d} I can't afford it anymore, Good Bye!..."
        );
    }
    #endregion
}
