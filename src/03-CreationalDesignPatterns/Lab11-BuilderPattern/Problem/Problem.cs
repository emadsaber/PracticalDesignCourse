namespace Builder.Problem;

public class GenericComputerBuilder
{
    public string Type { get; set; }
    public string Motherboard { get; set; }
    public string Processor { get; set; }
    public string Memory { get; set; }
    public string Hdd { get; set; }
    public string Screen { get; set; }
    public string Usb { get; set; }
    public string Wifi { get; set; }
    public GenericComputerBuilder(string type,
                                  string motherboard,
                                  string processor,
                                  string memory,
                                  string hdd,
                                  string usb,
                                  string screen = null,
                                  string wifi = null) { 
        Type = type;
        Motherboard = motherboard;
        Processor = processor;
        Memory = memory;
        Hdd = hdd;
        Screen= screen;
        Usb = usb;
        Wifi = wifi;
    }

    public Computer GetGenericComputer(){
        var computer = new Computer();
        if(Type == "laptop"){
            computer.Add(Motherboard);
            computer.Add(Processor);
            computer.Add(Memory);
            computer.Add(Hdd);
            computer.Add(Screen);
            computer.Add(Usb);
            computer.Add(Wifi);
        }else if(Type == "workstation"){
            computer.Add(Motherboard);
            computer.Add(Processor);
            computer.Add(Memory);
            computer.Add(Hdd);
            //computer.Add(Screen); //No screen for workstation
            computer.Add(Usb);
            //computer.Add(Wifi); //No Wifi for workstation
        }
        return computer;
    }
}
