namespace Builder.Solution;

public interface IComputerBuilder
{
    IComputerBuilder Reset();
    IComputerBuilder BuildMotherBoard(string motherboard);
    IComputerBuilder BuildProcessor(string processor);
    IComputerBuilder BuildMemory(int capacity);
    IComputerBuilder BuildHDD(int capacity);
    IComputerBuilder BuildScreen(double screenSize);
    IComputerBuilder BuildUsbPorts(int portsCount);
    IComputerBuilder BuildWifiCard(string wifi);
    Computer GetComputer();
}

public class ComputerBuilder : IComputerBuilder
{
    private Computer _computer;

    public ComputerBuilder()
    {
        this.Reset();
    }

    public IComputerBuilder Reset()
    {
        _computer = new Computer();
        return this;
    }

    public IComputerBuilder BuildMotherBoard(string motherboard)
    {
        _computer.Add($"Motherboard \t\t: {motherboard}");
        return this;
    }

    public IComputerBuilder BuildProcessor(string processor)
    {
        _computer.Add($"Processor \t\t: {processor}");
        return this;
    }

    public IComputerBuilder BuildMemory(int capacity)
    {
        _computer.Add($"Memory \t\t\t: {capacity} GB");
        return this;
    }

    public IComputerBuilder BuildHDD(int capacity)
    {
        _computer.Add($"HDD \t\t\t: {capacity} GB");
        return this;
    }

    public IComputerBuilder BuildScreen(double screenSize)
    {
        _computer.Add($"Screen \t\t\t: {screenSize} inches");
        return this;
    }

    public IComputerBuilder BuildUsbPorts(int portsCount)
    {
        _computer.Add($"Ports \t\t\t: {portsCount} ports");
        return this;
    }

    public IComputerBuilder BuildWifiCard(string wifi)
    {
        _computer.Add($"Wifi \t\t\t: {wifi}");
        return this;
    }

    public Computer GetComputer()
    {
        return _computer;
    }
}

public class ComputerDirector
{
    public Computer BuildLaptop(IComputerBuilder computerBuilder)
    {
        return computerBuilder
            .Reset()
            .BuildMotherBoard("Lenovo Legion 5")
            .BuildHDD(256)
            .BuildProcessor("Intel Core i5 10400F, #Cores: 8")
            .BuildMemory(16)
            .BuildUsbPorts(5)
            .BuildScreen(16)
            .BuildWifiCard("Inter Centrino Wireless i/b/g/n")
            .GetComputer();
    }

    public Computer BuildWorkstation(IComputerBuilder computerBuilder)
    {
        return computerBuilder
            .Reset()
            .BuildMotherBoard("Gigabyte Z790 Aorus Xtreme")
            .BuildHDD(1024)
            .BuildProcessor("Intel Core i7 10750H, #Cores: 16")
            .BuildMemory(64)
            .BuildUsbPorts(15)
            //.BuildScreen()
            //.BuildWifiCard()
            .GetComputer();
    }
}
