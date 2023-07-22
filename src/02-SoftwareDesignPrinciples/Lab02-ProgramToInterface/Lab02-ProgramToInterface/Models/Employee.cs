interface IEmployee{
    void DoWork();
}

class Designer: IEmployee {
    public void DoWork(){
        Console.WriteLine("Designer: I'm designing...");
    }
}

class Programmer: IEmployee {
    public void DoWork(){
        Console.WriteLine("Programmer: I'm writing code...");
    }
}

class Tester: IEmployee {
    public void DoWork(){
        Console.WriteLine("Tester: I'm testing programmer's code...");
    }
}

class Artist: IEmployee {
    public void DoWork(){
        Console.WriteLine("Artist: I'm drawing paintings...");
    }
}

class AnimationEditor: IEmployee {
    public void DoWork(){
        Console.WriteLine("AnimationEditor: I'm animating characters...");
    }
}