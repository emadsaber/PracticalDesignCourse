namespace Lab07_InterfaceSegregation;

class Program{
    public static void Main(string[]args){
        Console.WriteLine("|----------------- Problem Test ------------------|");
        var person_problem = new Problem.Person("Ramy", DateTime.Parse("1/1/2000"));
        person_problem.Eat();
        person_problem.DoWork();

        Console.WriteLine("|----------------- Solution Test ------------------|");
        var person_solution = new Solution.Person("Aya", DateTime.Parse("12/2/2006"));
        person_solution.Walk();
        person_solution.Resign();

        
    }
}