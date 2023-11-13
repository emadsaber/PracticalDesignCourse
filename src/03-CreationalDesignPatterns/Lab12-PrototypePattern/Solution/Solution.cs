namespace Prototype.Solution;

public interface ICloneable //we created it but C# already provides it out-of-the-box
{
    object Clone();
}

public class Person : ICloneable
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone(); //shallow copy
    }

    public override string ToString()
    {
        return $"Name: {Name:s}, Age: {Age:d}, BirthDate: {BirthDate:MM/dd/yyyy}, ID#: {IdInfo.IdNumber:d}";
    }

    public object Clone()
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        //clone.Name = String.Copy(Name);
        return clone;
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
