class Program
{
    public static void Main(string[] args) { 
        Console.WriteLine("---------- Outsourcing Company: ------------");
        var outsourcingCompany1 = new OutsourcingCompany();
        outsourcingCompany1.CreateSoftware();


        Console.WriteLine("---------- GameDev Company: ------------");
        var gameDevCompany1 = new GameDevCompany();
        gameDevCompany1.CreateSoftware();
    }
}
