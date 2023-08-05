namespace Lab07_InterfaceSegregation;

class Program{
    public static void Main(string[]args){
        Console.WriteLine("|----------------- Problem Test ------------------|");
        var person_problem = new Problem.Child("Ramy");
        person_problem.Eat();
        //person_problem.DoWork();

        Console.WriteLine("|----------------- Solution Test ------------------|");
        var child_solution = new Solution.Child("Moaz");
        child_solution.Walk();
        
        var person_solution = new Solution.Employee("Aya", DateTime.Parse("12/2/2006"));
        person_solution.Walk();
        person_solution.Resign();

        
    }
}