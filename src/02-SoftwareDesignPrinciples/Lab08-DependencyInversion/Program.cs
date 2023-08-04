namespace Lab08_DependencyInversion;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("|----------------- Problem Test ------------------|");
        var pReport = new Problem.BudgetReport(DateTime.Parse("1/1/2000"));
        pReport.PrintReports();
        pReport.Save();
        pReport.PrintReports();
        pReport.SetReportDate(DateTime.Parse("2/2/1999"));
        pReport.Save();
        pReport.PrintReports();
        Console.WriteLine("|----------------- Solution Test ------------------|");
        var sReport = new Solution.BudgetReport(DateTime.Parse("10/10/2020"));
        sReport.PrintReports();
        sReport.Save();
        sReport.PrintReports();
        sReport.SetReportDate(DateTime.Parse("12/12/2023"));
        sReport.Save();
        sReport.PrintReports();
    }
}
