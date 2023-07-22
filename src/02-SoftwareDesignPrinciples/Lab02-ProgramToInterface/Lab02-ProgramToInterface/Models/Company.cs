abstract class Company{
    public abstract List<IEmployee> GetEmployees();

    public void CreateSoftware(){
        var employees = GetEmployees();
        
        foreach(var employee in employees){
            employee.DoWork();
        }
    }
}

class OutsourcingCompany : Company{
    public override List<IEmployee> GetEmployees()
    {
        return new List<IEmployee>{
            new Programmer(),
            new Tester(),
        };
    }
}

class GameDevCompany : Company{
    public override List<IEmployee> GetEmployees()
    {
        return new List<IEmployee>{
            new Designer(),
            new AnimationEditor(),
            new Artist(),
        };
    }
}