using AbstractFactory.Solution;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-------------Problem Test---------");
        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("chair", "plastic", 110, 40)
        );
        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("table", "plastic", 100, 110)
        );
        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("spoon", "plastic", 12, 30)
        );

        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("chair", "wood", 120, 50)
        );
        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("table", "wood", 120, 120)
        );
        Console.WriteLine(
            AbstractFactory.Problem.Application.GetProductDetails("spoon", "wood", 15, 40)
        );

        Console.WriteLine("-------------Solution Test---------");
        new Application().ProduceBatch();
    }
}
