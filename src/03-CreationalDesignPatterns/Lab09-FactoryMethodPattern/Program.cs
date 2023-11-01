class Program{
    public static void Main(string[] args){
        
        //Testing Problem
        Console.WriteLine("-------------Problem Test---------");
        var problem = new FactoryMethod.Porblem.PizzaStore();
        problem.OrderPizza("pepproni");

        Console.WriteLine("-------------Solution Test---------");
        var solution = new FactoryMethod.Solution.PepproniPizzaKitchen();
        solution.GetPizza();
    }
}