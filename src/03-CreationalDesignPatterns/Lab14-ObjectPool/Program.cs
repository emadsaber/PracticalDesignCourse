// Example usage of the object pool
class Program
{
    static void Main(string[] args)
    {
        var problem = new Lab14_ObjectPool.Problem.Client();
        problem.Test();

        var solution = new Lab14_ObjectPool.Solution.Client();
        solution.Test();
    }
}
