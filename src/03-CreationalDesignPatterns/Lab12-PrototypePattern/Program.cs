class Program
{
    public static void Main(string[] args)
    {
        var problemPerson = new Prototype.Problem.Person();

        problemPerson.Name = "Ramy";
        problemPerson.Age = 23;
        problemPerson.BirthDate = Convert.ToDateTime("2000-01-01");
        problemPerson.IdInfo = new Prototype.Problem.IdInfo(11111);

        var shallowPerson = problemPerson.ShallowCopy();

        Console.WriteLine("-----------Problem : Persons before update------------");
        Console.WriteLine(problemPerson);
        Console.WriteLine(shallowPerson);

        //update values
        problemPerson.Age = 24;
        problemPerson.BirthDate = Convert.ToDateTime("1999-01-01");
        problemPerson.Name = "Ahmed";
        problemPerson.IdInfo.IdNumber = 22222;

        Console.WriteLine("-----------Problem : Persons after update------------");

        Console.WriteLine(problemPerson);
        Console.WriteLine(shallowPerson); //note that ID# for copied object is updated after updating original object

        ///////////////////////////////////////////////////////////////////////////////////////
        var solutionPerson = new Prototype.Solution.Person();
        solutionPerson.Name = "Hany";
        solutionPerson.Age = 47;
        solutionPerson.BirthDate = Convert.ToDateTime("1970-01-01");
        solutionPerson.IdInfo = new Prototype.Solution.IdInfo(3333);

        var clonedPerson = solutionPerson.Clone();

        Console.WriteLine("-----------Solution : Persons before update------------");
        Console.WriteLine(solutionPerson);
        Console.WriteLine(clonedPerson);

        //update values
        solutionPerson.Age = 57;
        solutionPerson.BirthDate = Convert.ToDateTime("1960-01-01");
        solutionPerson.Name = "Sayed";
        solutionPerson.IdInfo.IdNumber = 4444;

        Console.WriteLine("-----------Problem : Persons after update------------");

        Console.WriteLine(solutionPerson);
        Console.WriteLine(clonedPerson); //note that ID# for copied object is the same
    }
}
