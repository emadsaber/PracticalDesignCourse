namespace Lab08_DependencyInversion.Solution;

interface IEntity
{
    public Guid Id { get; set; }
}

interface IDatabase<T>
    where T : IEntity
{
    public void Insert(T item);
    public void Update(T item);
    public void Delete(T item);
    public IReadOnlyList<T> GetAll();
}

class BudgetReport : IEntity
{
    //You can change the type to MySqlDatabase<BudgetReport> and get the same result
    private IDatabase<BudgetReport> database = new MongoDbDatabase<BudgetReport>();
    public DateTime ReportDate { get; set; }

    public BudgetReport(DateTime reportDate)
    {
        Id = Guid.NewGuid();
        ReportDate = reportDate;
    }

    public void SetReportDate(DateTime reportDate)
    {
        ReportDate = reportDate;
    }

    public void Save()
    {
        database.Update(this);
    }

    public void PrintReports()
    {
        foreach (BudgetReport item in database.GetAll())
        {
            Console.WriteLine($"Report: {item.Id} - {item.ReportDate:d}");
        }
    }
}

class MySqlDatabase<T> : IDatabase<T>
    where T : IEntity
{
    private List<T> collection = new List<T>();

    public void Insert(T item)
    {
        collection.Add(item);
    }

    public void Update(T item)
    {
        Delete(item); //for simplification only, in real DBMS, item is updated
        collection.Add(item);
    }

    public void Delete(T item)
    {
        var existing = collection.Where(x => x.Id == item.Id);
        if (existing != null)
        {
            collection.Remove(item);
        }
    }

    public IReadOnlyList<T> GetAll()
    {
        return collection.AsReadOnly();
    }
}

class MongoDbDatabase<T> : IDatabase<T>
    where T : IEntity
{
    private HashSet<T> set = new HashSet<T>();

    public void Insert(T item)
    {
        set.Add(item);
    }

    public void Update(T item)
    {
        Delete(item); //for simplification only, in real DBMS, item is updated
        set.Add(item);
    }

    public void Delete(T item)
    {
        var existing = set.Where(x => x.Id == item.Id);
        if (existing != null)
        {
            set.Remove(item);
        }
    }

    public IReadOnlyList<T> GetAll()
    {
        return set.ToList();
    }
}
