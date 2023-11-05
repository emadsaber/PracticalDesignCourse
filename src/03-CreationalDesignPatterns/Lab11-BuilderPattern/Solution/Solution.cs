namespace Builder.Solution;

public interface IComputerBuilder
{
    void Reset();
    IComputerBuilder BuildMotherBoard();
    IComputerBuilder BuildProcessor();
    IComputerBuilder BuildMemory();
    IComputerBuilder BuildHDD();
    IComputerBuilder BuildScreen();
    IComputerBuilder BuildUsbPorts();
    IComputerBuilder BuildWifiCard();
    Computer GetComputer();
}

public class LaptopBuilder : IComputerBuilder
{
    private Computer _computer;

    public LaptopBuilder()
    {
        _computer = new Computer();
    }

    public void Reset()
    {
        _computer = new Computer();
    }

    public IComputerBuilder BuildMotherBoard()
    {
        _computer.Add($"Motherboard \t\t: Lenovo Legion 5");
        return this;
    }

    public IComputerBuilder BuildProcessor()
    {
        _computer.Add($"Processor \t\t: Intel Core i5 10400F, #Cores: 8");
        return this;
    }

    public IComputerBuilder BuildMemory()
    {
        _computer.Add($"Memory \t\t\t: 16 GB");
        return this;
    }

    public IComputerBuilder BuildHDD()
    {
        _computer.Add($"HDD \t\t\t: 256 GB");
        return this;
    }

    public IComputerBuilder BuildScreen()
    {
        _computer.Add($"Screen \t\t\t: 16 inches");
        return this;
    }

    public IComputerBuilder BuildUsbPorts()
    {
        _computer.Add($"Ports \t\t\t: 5 ports");
        return this;
    }

    public IComputerBuilder BuildWifiCard()
    {
        _computer.Add($"Wifi \t\t\t: Inter Centrino Wireless i/b/g/n");
        return this;
    }

    public Computer GetComputer()
    {
        return _computer;
    }
}

public class WorkstationBuilder : IComputerBuilder
{
    private Computer _computer;

    public WorkstationBuilder()
    {
        _computer = new Computer();
    }

    public void Reset()
    {
        _computer = new Computer();
    }

    public IComputerBuilder BuildMotherBoard()
    {
        _computer.Add($"Motherboard \t\t: Gigabyte Z790 Aorus Xtreme");
        return this;
    }

    public IComputerBuilder BuildProcessor()
    {
        _computer.Add($"Processor \t\t: Intel Core i7 10750H, #Cores: 16");
        return this;
    }

    public IComputerBuilder BuildMemory()
    {
        _computer.Add($"Memory \t\t\t: 64 GB");
        return this;
    }

    public IComputerBuilder BuildHDD()
    {
        _computer.Add($"HDD \t\t\t: 1 TB");
        return this;
    }

    public IComputerBuilder BuildScreen()
    {
        //Workstation computer doesn't have a screen
        return this;
    }

    public IComputerBuilder BuildUsbPorts()
    {
        _computer.Add($"Ports \t\t\t: 15 ports");
        return this;
    }

    public IComputerBuilder BuildWifiCard()
    {
        //Workstation computer doesn't have a WIFI card
        return this;
    }

    public Computer GetComputer()
    {
        return _computer;
    }
}

public class ComputerDirector
{
    public Computer BuildComputer(IComputerBuilder computerBuilder)
    {
        return computerBuilder
            .BuildMotherBoard()
            .BuildHDD()
            .BuildProcessor()
            .BuildMemory()
            .BuildUsbPorts()
            .BuildScreen()
            .BuildWifiCard()
            .GetComputer();
    }
}
