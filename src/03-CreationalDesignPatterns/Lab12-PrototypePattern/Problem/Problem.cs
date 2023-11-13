namespace Prototype.Problem;

public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone(); //shallow copy
    }

    public override string ToString(){
        return $"Name: {Name:s}, Age: {Age:d}, BirthDate: {BirthDate:MM/dd/yyyy}, ID#: {IdInfo.IdNumber:d}";
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        this.IdNumber = idNumber;
    }
}

