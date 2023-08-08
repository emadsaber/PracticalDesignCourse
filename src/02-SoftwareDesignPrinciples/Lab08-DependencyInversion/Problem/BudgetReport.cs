namespace Lab08_DependencyInversion.Problem;

interface IEntity
{
    public Guid Id { get; set; }
}

class BudgetReport : IEntity
{
    private MySqlDatabase<BudgetReport> database = new MySqlDatabase<BudgetReport>();
    public Guid Id { get; set; }
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

    public void PrintReports(){
        foreach(BudgetReport item in database.GetAll()){
            Console.WriteLine($"Report: {item.Id} - {item.ReportDate:d}");
        }
    }
}

class MySqlDatabase<T>
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
