namespace Lab03_SingleResponsibility.Problem;
class Invoice
{
    public string Serial { get; set; }
    public string EmployeeEmail { get; set; }
    public string EmployeeName { get; set; }
    public void SendEmail()
    {
        Console.WriteLine(
            $"Hi {EmployeeName}, An invoice with serial {Serial} "
                + $"was successfully sent to your email: {EmployeeEmail}"
        );
    }
}
