namespace Singleton.ThreadSafeSolution;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Student => Id: {Id}, Name: {Name}";
    }
}

class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public override string ToString()
    {
        return $"Department => Id: {Id}, Name: {Name}, Code: {Code}";
    }
}

class InMemoryDatabase
{
    private static InMemoryDatabase _instance;
    private static readonly object _lock = new object();
    public string Identifier { get; set; }

    public static InMemoryDatabase GetInstance(string identifier)
    {
        lock (_lock) //to be thread-safe
        {
            if (_instance == null)
            {
                _instance = new InMemoryDatabase();
                _instance.Identifier = identifier;
            }
        }

        return _instance;
    }

    private InMemoryDatabase()
    {
        Students = new List<Student>();
        Departments = new List<Department>();
    }

    public List<Student> Students { get; set; }

    public List<Department> Departments { get; set; }

    public void PrintAll()
    {
        Console.WriteLine($"--------Printing {Students?.Count ?? 0} Students-----------");
        foreach (var s in Students)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine($"--------Printing {Departments?.Count ?? 0} Departments-----------");
        foreach (var d in Departments)
        {
            Console.WriteLine(d);
        }
    }
}

class Client
{
    public void CreateDatabaseInstanceThread(string identifier)
    {
        var db = InMemoryDatabase.GetInstance(identifier);

        Console.WriteLine(
            $"--------Printing the database instance identifier: {db.Identifier}-----------"
        );
    }

    public void Test()
    {
        Thread process1 = new Thread(() =>
        {
            CreateDatabaseInstanceThread("thread 1");
        });
        Thread process2 = new Thread(() =>
        {
            CreateDatabaseInstanceThread("thread 2");
        });

        Thread process3 = new Thread(() =>
        {
            CreateDatabaseInstanceThread("thread 3");
        });
        Thread process4 = new Thread(() =>
        {
            CreateDatabaseInstanceThread("thread 4");
        });
        process1.Start();
        process2.Start();
        process3.Start();
        process4.Start();

        process1.Join();
        process2.Join();
        process3.Join();
        process4.Join();
    }
}
