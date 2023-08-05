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

    public void DoWork()
    {
        throw new NotImplementedException("Child is not working");
    }
    
    public void Resign()
    {
        throw new NotImplementedException("Child is not working");
    }

    #endregion
}
