namespace Singleton.ThreadSafeSolution;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }

    public override string ToString()
    {
        return $"Student => Id: {Id}, Name: {Name}, CreatedBy: {CreatedBy}";
    }
}

class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string CreatedBy { get; set; }

    public override string ToString()
    {
        return $"Department => Id: {Id}, Name: {Name}, Code: {Code}, CreatedBy: {CreatedBy}";
    }
}

class InMemoryDatabase
{
    private static InMemoryDatabase _instance;
    private static readonly object _lock = new object();

    public static InMemoryDatabase GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock) //to be thread-safe
            {
                _instance = new InMemoryDatabase();
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
    public void CreateDatabaseInstanceThread(string identifier) {
        var db = InMemoryDatabase.GetInstance();
        
        db.Departments.Add(
            new Department
            {
                Id = db.Departments.Count + 1,
                Code = "D1",
                Name = "Computer Science",
                CreatedBy = identifier
            }
        );
        db.Departments.Add(
            new Department
            {
                Id = db.Departments.Count + 1,
                Code = "D2",
                Name = "Information Technology",
                CreatedBy = identifier
            }
        );
        db.Students.Add(new Student { Id = db.Students.Count + 1, Name = "Moaz", CreatedBy = identifier});
        db.Students.Add(new Student { Id = db.Students.Count + 1, Name = "Marawan", CreatedBy = identifier });

        Console.WriteLine($"--------Printing the first object content:-----------");
        db.PrintAll();
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

        process1.Start();
        process2.Start();

        process1.Join();
        process2.Join();
    }
}
