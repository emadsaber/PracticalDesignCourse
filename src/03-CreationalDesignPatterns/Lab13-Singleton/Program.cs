Console.WriteLine("----------------------------Problem Test--------------------------");
var problem = new Singleton.Problem.Client();

//problem.Test();

Console.WriteLine("----------------------------Solution Test--------------------------");
var solution = new Singleton.Solution.Client();

//solution.Test();

Console.WriteLine("----------------------------Thread-Safe Solution Test--------------------------");
var threadSafeSolution = new Singleton.ThreadSafeSolution.Client();

threadSafeSolution.Test();