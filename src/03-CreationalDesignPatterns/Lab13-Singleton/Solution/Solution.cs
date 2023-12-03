namespace Singleton.Solution;

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

    public static InMemoryDatabase GetInstance(){
        if(_instance == null) {
            _instance = new InMemoryDatabase();
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
    public void Test()
    {
        var db1 = InMemoryDatabase.GetInstance();

        db1.Departments.Add(
            new Department
            {
                Id = 1,
                Code = "D1",
                Name = "Computer Science"
            }
        );
        db1.Departments.Add(
            new Department
            {
                Id = 2,
                Code = "D2",
                Name = "Information Technology"
            }
        );
        db1.Students.Add(new Student { Id = 1, Name = "Moaz" });
        db1.Students.Add(new Student { Id = 2, Name = "Marawan" });


        Console.WriteLine($"--------Printing the first object content:-----------");
        db1.PrintAll();

        //Now, we will get another database object
        var db2 = InMemoryDatabase.GetInstance();
        db2.Students.Add(new Student{Id = 3, Name = "Ahmed"});

         //Expected: Show 2 Departments and 3 students
         //Actual : Show 2 Departments and 3 students :)
        Console.WriteLine($"--------Printing the second object content:-----------");
        db2.PrintAll();
    }
}
