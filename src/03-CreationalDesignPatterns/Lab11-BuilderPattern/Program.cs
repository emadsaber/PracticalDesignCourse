class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("================Problem Test================");
        var geneicBuilder1 = new Builder.Problem.GenericComputerBuilder(
            "laptop",
            motherboard: "Motherboard \t\t: Lenovo Legion 5",
            processor: "Processor \t\t: Intel Core i5 10400F, #Cores: 8",
            memory: "Memory \t\t\t: 16 GB",
            hdd: "HDD \t\t\t: 256 GB",
            screen: "Screen \t\t\t: 16 inches",
            usb: "Ports \t\t\t: 5 ports",
            wifi: "Wifi \t\t\t: Inter Centrino Wireless i/b/g/n"
        );
        var laptop1 = geneicBuilder1.GetGenericComputer();

        Console.WriteLine("----------Problem :: Printing Laptop Information-------");
        Console.WriteLine(laptop1);

        var geneicBuilder2 = new Builder.Problem.GenericComputerBuilder(
            "workstation",
            motherboard: "Motherboard \t\t: Gigabyte Z790 Aorus Xtreme",
            processor: "Processor \t\t: Intel Core i7 10750H, #Cores: 16",
            memory: "Memory \t\t\t: 64 GB",
            hdd: "HDD \t\t\t: 1 TB",
            usb: "Ports \t\t\t: 15 ports",
            screen: null,
            wifi: null
        );
        var workstation1 = geneicBuilder2.GetGenericComputer();
        Console.WriteLine("----------Problem :: Printing Workstation Information-------");
        Console.WriteLine(workstation1);

        Console.WriteLine("================Solution Test================");
        var director = new Builder.Solution.ComputerDirector();
        var computerBuilder = new Builder.Solution.ComputerBuilder();

        var laptop2 = director.BuildLaptop(computerBuilder);
        var workstation2 = director.BuildWorkstation(computerBuilder);

        Console.WriteLine("----------Solution :: Printing Laptop Information-------");
        Console.WriteLine(laptop2);

        Console.WriteLine("----------Solution :: Printing Workstation Information----------");
        Console.WriteLine(workstation2);
    }
}
